using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Algyan.Gadgeteer.Sensors
{
    public class DebugLed : Algyan.Gadgeteer.Modules.DebugLed
    {
        public DebugLed(Cpu.Pin pin)
        {
            LedPort = new OutputPort(pin, false);
        }
    }
}
