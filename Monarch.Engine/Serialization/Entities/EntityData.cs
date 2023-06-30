using Monarch.Engine.ECS.Entities;
using Monarch.Engine.Maths;

namespace SpiceEngine.Core.Serialization.Entities
{
    public abstract class EntityData : GameData, IEntityBuilder, IAttachedEntityBuilder
    {
        public Vector3f Position { get; set; } = Vector3f.Zero;
        public Vector3f Rotation { get; set; } = Vector3f.Zero;
        public Vector3f Scale { get; set; } = Vector3f.One;

        public bool IsAttached { get; set; }
        public AttachData? Attachment { get; set; }

        public override bool IsValid => Position.IsReal && Rotation.IsReal && Scale.IsReal
            && Scale.X > 0.0f && Scale.Y > 0.0f && Scale.Z > 0.0f
            && (!IsAttached || Attachment != null);

        public abstract IEntity Build(int id);

        public override void LoadData(IDataReader reader)
        {
            base.LoadData(reader);

            Position = reader.ReadVector3();
            Rotation = reader.ReadVector3();
            Scale = reader.ReadVector3();
            IsAttached = reader.ReadBoolean();

            if (IsAttached)
            {
                Attachment = new();
                Attachment.LoadData(reader);
            }
        }

        public override void SaveData(IDataWriter writer)
        {
            base.SaveData(writer);

            writer.WriteVector3(Position);
            writer.WriteVector3(Rotation);
            writer.WriteVector3(Scale);
            writer.WriteBoolean(IsAttached);

            if (IsAttached)
            {
                Attachment!.SaveData(writer);
            }
        }
    }
}