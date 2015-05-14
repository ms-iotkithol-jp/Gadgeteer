using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Algyan.Gadgeteer.Modules
{
    public abstract class DebugLed
    {
        public OutputPort LedPort { get; protected set; }

        public void SetDebugLed(bool on)
        {
            if (LedPort == null)
                return;

            LedPort.Write(on);
        }

        public void PulseDebugLed()
        {
            (new Thread(() =>
            {
                SetDebugLed(true);
                Thread.Sleep(100);
                SetDebugLed(false);
            })).Start();
        }

        public void PulseDebugLed(int length, int times)
        {
            (new Thread(() =>
            {
                for (var i = 0; i < times; i++)
                {
                    SetDebugLed(true);
                    Thread.Sleep(length);
                    SetDebugLed(false);
                    Thread.Sleep(length);
                }
            })).Start();
        }
    }
}
