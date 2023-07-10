using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Monarch.WindowsApp.Managers
{
    internal class GameManager : Monarch.Engine.ECS.Game.GameManager
    {
        private IWindow? _window;

        public override void Load()
        {
            var windowOptions = WindowOptions.Default;
            windowOptions.Size = new Vector2D<int>(1600, 1000);
            windowOptions.Title = "Title";
            windowOptions.ShouldSwapAutomatically = true;
            windowOptions.IsContextControlDisabled = false;

            _window = Window.Create(windowOptions);
            _window.Load += Window_Load;
            _window.Update += Update;
            _window.Render += Render;
            _window.Closing += Close;
        }

        public override void Start()
        {
            _window?.Run();
            _window?.Dispose();
        } 

        private void Window_Load()
        {
            var simulator = new SimulationManager();
            simulator.SetView(_window!);
            simulator.Load();
            SetSimulator(simulator);
            
            var renderer = new RenderManager();
            renderer.SetView(_window!);
            renderer.Load();
            SetRenderer(renderer);
        }
    }
}
