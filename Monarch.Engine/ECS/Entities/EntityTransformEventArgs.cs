using Monarch.Engine.Maths;

namespace Monarch.Engine.ECS.Entities
{
    public class EntityTransformEventArgs : EventArgs
    {
        public EntityTransformEventArgs(int id, Vector3f translation, Quaternion rotation, Vector3f scale)
        {
            ID = id;
            Translation = translation;
            Rotation = rotation;
            Scale = scale;
        }

        public int ID { get; }
        public Vector3f Translation { get; }
        public Quaternion Rotation { get; }
        public Vector3f Scale { get; }
    }
}
