using Monarch.Engine.ECS.Entities;

namespace Monarch.Engine.ECS.Systems
{
    public class SimulationManager : ISimulate
    {
        private ISystemProvider? _systemProvider;

        public void SetSystemProvider(ISystemProvider systemProvider) => _systemProvider = systemProvider;

        public void Load()
        {
            var entityManager = new EntityManager();

        }

        public void Start()
        {

        }

        public void Update(float deltaTime)
        {
            foreach (var gameSystem in _systemProvider!.GetGameSystems())
            {
                gameSystem.Update(deltaTime);
            }
        }
    }
}
