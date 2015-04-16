using System;
using Microsoft.SPOT;

namespace Algyan.Gadgeteer.Modules
{
    public abstract class Relay
    {
        public abstract void TurnOn();
        public abstract void TurnOff();
    }
}