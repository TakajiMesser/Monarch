namespace SpiceEngine.Core.Serialization.Entities
{
    public class AttachData : GameData
    {
        public string? AttachedEntityName { get; set; }

        public bool AttachTranslation { get; set; }
        public bool AttachRotation { get; set; }
        public bool AttachScale { get; set; }

        public override bool IsValid => !string.IsNullOrEmpty(AttachedEntityName)
            && (AttachTranslation || AttachRotation || AttachScale);

        public override void LoadData(IDataReader reader)
        {
            base.LoadData(reader);

            AttachedEntityName = reader.ReadString();
            AttachTranslation = reader.ReadBoolean();
            AttachRotation = reader.ReadBoolean();
            AttachScale = reader.ReadBoolean();
        }

        public override void SaveData(IDataWriter writer)
        {
            base.SaveData(writer);

            writer.WriteString(AttachedEntityName!);
            writer.WriteBoolean(AttachTranslation);
            writer.WriteBoolean(AttachRotation);
            writer.WriteBoolean(AttachScale);
        }
    }
}