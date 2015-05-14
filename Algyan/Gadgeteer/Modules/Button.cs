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

        public event ButtonEventHandler ButtonPressed;
        public event ButtonEventHandler ButtonReleased;

        private Thread _infiniteThread;
        private bool _prevPressed;

        public InterruptPort ButtonPort { get; protected set; }

        public void StartInterrupt()
        {
            ButtonPort.OnInterrupt += ButtonPort_OnInterrupt;

            _infiniteThread = new Thread(() =>
            {
                Thread.Sleep(Timeout.Infinite);
            });
            _infiniteThread.Start();
        }
        void ButtonPort_OnInterrupt(uint data1, uint data2, System.DateTime time)
        {
            var isPressed = data2 == 0;

            if (isPressed && !_prevPressed && ButtonPressed != null)
                ButtonPressed(this, ButtonState.Pressed);
            else if (!isPressed && _prevPressed && ButtonReleased != null)
                ButtonReleased(this, ButtonState.Released);

            _prevPressed = isPressed;
        }

        public bool IsPressed
        {
            get
            {
                lock (this)
                {
                    return !ButtonPort.Read();
                }
            }
        }
    }
}
