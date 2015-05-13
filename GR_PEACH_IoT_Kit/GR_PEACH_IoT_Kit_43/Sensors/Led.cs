using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Algyan.Gadgeteer.Sensors
{
    public class Led : Algyan.Gadgeteer.Modules.Led
    {
        public Led(Cpu.Pin pin)
        {
            LedPort = new OutputPort(pin, false);
        }
    }
}
