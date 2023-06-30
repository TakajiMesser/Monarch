using Monarch.Engine.ECS.Entities;

namespace SpiceEngine.Core.Serialization.Entities
{
    public interface ISceneBuilder
    {
        int CameraCount { get; }
        int BrushCount { get; }
        int ActorCount { get; }
        int LightCount { get; }
        int VolumeCount { get; }
        int UIItemCount { get; }

        IEnumerable<IEntityBuilder> GetBuilders();
    }
}