namespace Monarch.Shared.Models.Resources
{
    public class Resource : IResource
    {
        public Resource(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; }
        public string Name { get; }
    }
}
