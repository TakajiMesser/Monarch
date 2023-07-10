using Silk.NET.Input;
using Silk.NET.SDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monarch.Engine.HID.Inputs
{
    public record struct ButtonBinding(
        Key Key = Key.Unknown,
        MouseButton MouseButton = MouseButton.Unknown,
        GameControllerButton GamepadButton = GameControllerButton.Invalid
        );
}
