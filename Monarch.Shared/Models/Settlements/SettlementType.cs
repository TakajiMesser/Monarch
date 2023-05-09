namespace Monarch.Shared.Models.Settlements
{
    public enum SettlementType
    {
        Tribe, // <= 150
        Village, // 150 to 10,000
        Town, // 10,000 to 100,000
        City, // 100,000 to 1,000,000
        Metropolis // >= 1,000,000
    }
}
