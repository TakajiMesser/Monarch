namespace Monarch.Shared.Models.Units
{
    public class Unit : IUnit
    {
        public Unit(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
