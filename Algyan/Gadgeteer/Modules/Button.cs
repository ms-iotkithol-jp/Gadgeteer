using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Algyan.Gadgeteer.Modules
{
    public delegate void ButtonEventHandler(Button sender, Button.ButtonState state);

    public abstract class Button
    {
        public enum ButtonState
        {
            Pressed,
            Released
        }

        public InterruptPort ButtonPort { get; protected set; }

        protected bool PrevPressed;

        private Thread _infiniteThread;

        public event ButtonEventHandler ButtonPressed;
        public event ButtonEventHandler ButtonReleased;
    }
}
