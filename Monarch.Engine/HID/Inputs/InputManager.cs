using Monarch.Engine.ECS.Systems;
using Silk.NET.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monarch.Engine.HID.Inputs
{
    public class InputManager : GameSystem
    {
        public void SetInputContext(IInputContext inputContext)
        {
            var keyboard = inputContext.Keyboards.FirstOrDefault();

            if (keyboard != null)
            {
                //keyboard.IsKeyPressed
            }
        }

        public override void Load()
        {
            base.Load();
        }

        public override void Update(double deltaTime)
        {
            
        }

        public bool IsDown()
        {
            return false;
        }
    }
}
