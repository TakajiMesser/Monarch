namespace Monarch.Shared.Models.Structures
{
    public class Structure : IStructure
    {
        public Structure(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
