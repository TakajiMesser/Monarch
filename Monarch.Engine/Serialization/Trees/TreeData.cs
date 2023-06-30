using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpiceEngine.Core.Serialization.Trees
{
    public class TreeData
    {
        public NodeData[] Nodes { get; set; }

        public Node Build() => BuildNodeWithIndex().Item1;

        private Tuple<Node, int> BuildNodeWithIndex(int index = 0)
        {
            var data = Nodes[index];
            var childNodes = new Node[data.ChildCount];
            index++;

            for (var i = 0; i < data.ChildCount; i++)
            {
                var result = BuildNodeWithIndex(index);

                childNodes[i] = result.Item1;
                index = result.Item2;
            }

            return Tuple.Create(data.Build(childNodes), index);
        }

        public static TreeData FromNode(Node root) => new()
        {
            Nodes = ToData(root).ToArray()
        };

        private static IEnumerable<NodeData> ToData(Node node)
        {
            yield return NodeData.FromNode(node);

            foreach (var child in node.Children)
            {
                foreach (var data in ToData(child))
                {
                    yield return data;
                }
            }
        }

        public void Log()
        {
            var builder = new StringBuilder();
            builder.Append('[');

            for (var i = 0; i < Nodes.Length; i++)
            {
                if (i > 0)
                {
                    builder.Append(", ");
                }

                var node = Nodes[i];
                builder.Append(node.Value);
            }

            builder.Append(']');
            Console.WriteLine(builder.ToString());
        }
    }
}