using Monarch.Engine.Maths;

namespace Monarch.Engine.ECS.Entities
{
    public class Entity : IEntity
    {
        public Entity(int id) => ID = id;

        public int ID { get; }

        public Vector3f Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3f Scale { get; set; }

        public Matrix4 ModelMatrix => Matrix4.CreateScale(Scale) * Matrix4.CreateFromQuaternion(Rotation) * Matrix4.CreateTranslation(Position);

        public event EventHandler<EntityTransformEventArgs>? Transformed;

        public void Attach(IEntity entity, bool attachTranslation, bool attachRotation, bool attachScale)
        {
            
        }

        public void Detach()
        {

        }
    }
}
