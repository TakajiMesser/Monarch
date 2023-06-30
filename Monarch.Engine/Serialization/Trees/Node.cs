using SpiceEngine.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpiceEngine.Core.Serialization.Trees
{
    public class Node
    {
        public Node(char value, IEnumerable<Node> children)
        {
            Value = value;
            Children = children.ToList();
        }

        public char Value { get; }
        public List<Node> Children { get; }

        private int GetHeight()
        {
            var height = 0;

            foreach (var child in Children)
            {
                var childHeight = child.GetHeight();

                if (childHeight > height)
                {
                    height = childHeight;
                }
            }

            return height + 1;
        }

        public void Log()
        {
            var builder = new StringBuilder();
            //var height = GetHeight();

            var nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(this);

            while (nodeQueue.Count > 0)
            {
                var nNodes = nodeQueue.Count;
                
                while (nNodes > 0)
                {
                    var node = nodeQueue.Dequeue();
                    builder.Append(node.Value);

                    foreach (var child in node.Children)
                    {
                        nodeQueue.Enqueue(child);
                    }

                    nNodes--;
                }

                Console.WriteLine(builder.ToString());
                builder.Clear();
            }
        }

        public static Node TestTree() => new('A', new[]
        {
            new Node('B', new[]
            {
                new Node('D', Array.Empty<Node>()),
                new Node('E', new[]
                {
                    new Node('F', Array.Empty<Node>()),
                    new Node('G', Array.Empty<Node>()),
                    new Node('H', Array.Empty<Node>())
                })
            }),
            new Node('C', new[]
            {
                new Node('I', Array.Empty<Node>()),
            })
        });
    }
}