using Monarch.Engine.ECS.Components;
using Monarch.Engine.Maths;

namespace SpiceEngine.Core.Serialization.Components
{
    public abstract class ComponentData<T> : GameData, IComponentBuilder<T> where T : IComponent
    {
        public Vector3f Position { get; set; } = Vector3f.Zero;

        public override bool IsValid => Position.IsReal;

        public abstract T Build(int id);

        public override void LoadData(IDataReader reader)
        {
            base.LoadData(reader);
            Position = reader.ReadVector3();
        }

        public override void SaveData(IDataWriter writer)
        {
            base.SaveData(writer);
            writer.WriteVector3(Position);
        }
    }
}