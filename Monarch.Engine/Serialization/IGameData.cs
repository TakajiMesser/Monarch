namespace SpiceEngine.Core.Serialization
{
    public interface IGameData
    {
        bool IsValid { get; }

        void LoadData(IDataReader reader);
        void SaveData(IDataWriter writer);
    }
}