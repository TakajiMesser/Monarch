using Monarch.Engine.Maths;

namespace Monarch.Engine.ECS.Entities
{
    public interface IEntity
    {
        int ID { get; }

        Vector3f Position { get; set; }
        Quaternion Rotation { get; set; }
        Vector3f Scale { get; set; }

        Matrix4 ModelMatrix { get; }

        event EventHandler<EntityTransformEventArgs>? Transformed;

        void Attach(IEntity entity, bool attachTranslation, bool attachRotation, bool attachScale);
        void Detach();
    }
}
