using Monarch.Engine.ECS.Entities;

namespace SpiceEngine.Core.Serialization.Entities
{
    public abstract class NamedEntityData : EntityData
    {
        public string? Name { get; set; }

        public override bool IsValid => base.IsValid
            && !string.IsNullOrEmpty(Name);

        public override void LoadData(IDataReader reader)
        {
            base.LoadData(reader);
            Name = reader.ReadString();
        }

        public override void SaveData(IDataWriter writer)
        {
            base.SaveData(writer);
            writer.WriteString(Name!);
        }
    }
}