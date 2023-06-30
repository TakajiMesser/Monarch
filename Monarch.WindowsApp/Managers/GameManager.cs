using Monarch.Engine.HID;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace Monarch.WindowsApp.Managers
{
    internal class GameManager
    {
        private IWindow? _window;
        private GL? _gl;
        private IInputContext? _inputContext;

        private SimulationManager? _simulationManager;
        private RenderManager? _renderManager;

        public void Load()
        {
            var windowOptions = WindowOptions.Default;
            windowOptions.Size = new Vector2D<int>(800, 600);
            windowOptions.Title = "Title";
            windowOptions.ShouldSwapAutomatically = true;
            windowOptions.IsContextControlDisabled = false;

            _window = Window.Create(windowOptions);
            _window.Load += Window_Load;
            _window.Update += Window_Update;
            _window.Render += Window_Render;
            _window.Closing += Window_Closing;
        }

        public void Start()
        {
            _window?.Run();
            _window?.Dispose();
        }

        private void Window_Load()
        {
            _gl = _window?.CreateOpenGL();
            _inputContext = _window?.CreateInput();

            _simulationManager = new();
            _simulationManager.Load(_inputContext!);

            var keyboard = _inputContext!.Keyboards.First();
            keyboard.KeyDown += (keyboard, key, number) =>
            {
                if (key == Key.Escape)
                {
                    _window?.Close();
                }
            };

            var display = new Display((uint)_window!.Size.X, (uint)_window!.Size.Y, _window!.WindowState == WindowState.Fullscreen);
            _window!.Resize += (size) =>
            {
                display.Window = new Resolution((uint)size.X, (uint)size.Y);
            };

            _renderManager = new();
            _renderManager.Load(_gl!, display);
        }

        private void Window_Update(double deltaTime)
        {
            _simulationManager?.Update(deltaTime);
        }

        private void Window_Render(double deltaTime)
        {
            _renderManager?.Render(deltaTime);
        }

        private void Window_Closing()
        {
            _simulationManager?.Close();
            _renderManager?.Close();
        }
    }
}
