using System;
using Microsoft.SPOT;

namespace EGIoTKit.Gadgeteer.Modules
{
    public abstract class TemperatureSensorModule
    {
        public TemperatureSensorModule(int socketNumber)
        {
            ;
        }

        public TemperatureSensorModule()
        {

        }

        public TimeSpan MeasurementInterval
        {
            get { return measurementInterval; }
            set { measurementInterval = value; }
        }

        public abstract void StartTakingMeasurements();
        public abstract void StopTakingMeasurements();
        public abstract Measurement TakeMeasurements();

        public event MeasurementCompleteEventHandler MeasurementComplete;

        public delegate void MeasurementCompleteEventHandler(TemperatureSensorModule sender, MeasurementCompleteEventArgs e);

        public class MeasurementCompleteEventArgs : EventArgs
        {
            public Measurement Measurement { get; set; }
            public override string ToString()
            {
                return Measurement.ToString();
            }
        }

        protected void OnMeasurementComplete()
        {
            if (MeasurementComplete != null)
            {
                MeasurementComplete(this, new MeasurementCompleteEventArgs() { Measurement = TakeMeasurements() });
            }
        }
        public class Measurement
        {
            public double Temperature { get; set; }
            public override string ToString()
            {
                return "T=" + Temperature;
            }
        }

        protected Measurement currentValue;
        protected TimeSpan measurementInterval;
    }
}
