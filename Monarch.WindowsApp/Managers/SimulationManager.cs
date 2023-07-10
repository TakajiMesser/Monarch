using Monarch.Engine.ECS.Entities;
using Silk.NET.Input;
using Silk.NET.Windowing;

namespace Monarch.WindowsApp.Managers
{
    internal class SimulationManager : Monarch.Engine.ECS.Game.SimulationManager
    {
        private IInputContext? _inputContext;

        public void SetInputContext(IInputContext inputContext) => _inputContext = inputContext;

        public override void SetView(IView view)
        {
            base.SetView(view);
            _inputContext = view.CreateInput();
        }

        public override void Load()
        {
            var entityManager = new EntityManager();

            var keyboard = _inputContext!.Keyboards.First();
            keyboard.KeyDown += (keyboard, key, number) =>
            {
                if (key == Key.Escape)
                {
                    _view?.Close();
                }
                else if (key == Key.P)
                {
                    _systemProvider?.Renderer?.TakeScreenshot();
                }
            };
        }

        public override void Start()
        {

        }

        public override void Update(double deltaTime)
        {
            foreach (var gameSystem in _systemProvider!.GetGameSystems())
            {
                gameSystem.Update(deltaTime);
            }
        }

        public override void Close()
        {

        }
    }
}
