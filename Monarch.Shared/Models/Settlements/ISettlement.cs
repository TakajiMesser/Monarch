namespace Monarch.Shared.Models.Settlements
{
    public interface ISettlement : IModel
    {
        SettlementType SettlementType { get; }
        bool IsCapital { get; }
        int Population { get; }

        void ApplyStructureModifiers();
        void UpdatePopulation();
    }
}
