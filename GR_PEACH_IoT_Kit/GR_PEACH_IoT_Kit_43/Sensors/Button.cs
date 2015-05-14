using System;
using System.Threading;
using Algyan.Gadgeteer.Modules;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Algyan.Gadgeteer.Sensors
{
    public class Button : Algyan.Gadgeteer.Modules.Button
    {
        public Button(Cpu.Pin pin)
        {
            ButtonPort = new InterruptPort(pin, true, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);
            StartInterrupt();
        }
    }
}
