using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace Monarch.WindowsApp.Managers
{
    internal class SimulationManager
    {
        private IInputContext? _inputContext;

        public void Load(IInputContext inputContext)
        {
            _inputContext = inputContext;
        }

        public void Update(double deltaTime)
        {

        }

        public void Close()
        {

        }
    }
}
