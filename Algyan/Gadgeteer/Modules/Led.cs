using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Algyan.Gadgeteer.Modules
{
    public abstract class Led
    {
        public OutputPort LedPort { get; protected set; }

        public void SetLed(bool on)
        {
            LedPort.Write(on);
        }
    }
}
