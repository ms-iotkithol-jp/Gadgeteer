using System;
using Microsoft.SPOT;
using Gadgeteer;

namespace Algyan.Gadgeteer
{
    public abstract class IoTKitBoard : Mainboard
    {
        public abstract Algyan.Gadgeteer.Modules.AccelerometerSensor AccelerometerSensor { get; }
        public abstract Algyan.Gadgeteer.Modules.TemperatureSensor TemperatureSensor { get; }
        public abstract Algyan.Gadgeteer.Modules.Relay Relay { get; }

        public abstract Algyan.Gadgeteer.Modules.DebugLed DebugLed { get; }

        public ILogger Logger { get; set; }
        public const string EOL = "\\n";
    }

    public interface ILogger
    {
        void Write(string log);
        void WriteLine(string log);
    }

}
