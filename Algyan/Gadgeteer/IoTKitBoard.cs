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
        public abstract Algyan.Gadgeteer.Modules.Led RedLed { get; }
        public abstract Algyan.Gadgeteer.Modules.Led GreenLed { get; }
        public abstract Algyan.Gadgeteer.Modules.Led BlueLed { get; }

        public abstract Algyan.Gadgeteer.Modules.Button Button { get; }

        public abstract void PulseDebugLed();
        public abstract void PulseDebugLed(int length, int times);

        public ILogger Logger { get; set; }
        public const string EOL = "\\n";
    }

    public interface ILogger
    {
        void Write(string log);
        void WriteLine(string log);
    }

}
