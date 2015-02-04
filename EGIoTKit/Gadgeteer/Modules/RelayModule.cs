using System;
using Microsoft.SPOT;
using Gadgeteer.Modules;

namespace EGIoTKit.Gadgeteer.Modules
{
    public abstract class RelayModule : Module
    {
        public RelayModule(int socketNumber)
        {
            ;
        }

        public RelayModule()
        {

        }

        public abstract void TurnOff();
        public abstract void TurnOn();
    }
}
