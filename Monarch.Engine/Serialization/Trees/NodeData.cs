namespace SpiceEngine.Core.Serialization.Trees
{
    public class NodeData
    {
        public int ChildCount { get; set; }
        public char Value { get; set; }

        public Node Build(IEnumerable<Node> nodes) => new(Value, nodes);

        public static NodeData FromNode(Node node) => new()
        {
            ChildCount = node.Children.Count,
            Value = node.Value
        };
    }
}