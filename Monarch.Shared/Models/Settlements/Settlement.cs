namespace Monarch.Shared.Models.Settlements
{
    public class Settlement : ISettlement
    {
        public Settlement(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
        public SettlementType SettlementType { get; private set; }
        public bool IsCapital { get; private set; }
        public int Population { get; private set; }

        public void ApplyStructureModifiers()
        {

        }

        public void UpdatePopulation()
        {

        }
    }
}
