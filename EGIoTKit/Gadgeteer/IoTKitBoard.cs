using System;
using Microsoft.SPOT;
using Gadgeteer;

namespace EGIoTKit.Gadgeteer
{
    public abstract class IoTKitBoard : Mainboard
    {
        public abstract EGIoTKit.Gadgeteer.Modules.AccelerometerSensorModule AccelerometerSensor { get; }
        public abstract EGIoTKit.Gadgeteer.Modules.TemperatureSensorModule TemperatureSensor { get; }
        public abstract EGIoTKit.Gadgeteer.Modules.RelayModule Relay { get; }

        public ILogger Logger { get; set; }
        public const string EOL = "\\n";
    }

    public interface ILogger
    {
        void Write(string log);
        void WriteLine(string log);
    }

}
