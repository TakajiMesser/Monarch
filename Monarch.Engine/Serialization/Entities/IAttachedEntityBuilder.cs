using Monarch.Engine.ECS.Entities;

namespace SpiceEngine.Core.Serialization.Entities
{
    public interface IAttachedEntityBuilder : IEntityBuilder
    {
        bool IsAttached { get; }
        AttachData? Attachment { get; }
    }
}