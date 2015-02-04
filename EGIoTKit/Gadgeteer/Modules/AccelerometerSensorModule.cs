using System;
using Microsoft.SPOT;
using Gadgeteer.Modules;

namespace EGIoTKit.Gadgeteer.Modules
{
    public abstract class AccelerometerSensorModule : Module
    {
        public AccelerometerSensorModule(int socketNumber)
        {
            ;
        }

        public AccelerometerSensorModule()
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

        public event MeasurementCompleteEventHandler MeasuremntComplete;
        public delegate void MeasurementCompleteEventHandler(AccelerometerSensorModule sender, MeasurementCompleteEventArgs e);

        public class MeasurementCompleteEventArgs : EventArgs
        {
            public Measurement Measurement { get; set; }
            public override string ToString()
            {
                return Measurement.ToString();
            }
        }

        protected void OnMeasarementComplete()
        {
            if (MeasuremntComplete != null)
            {
                MeasuremntComplete(this, new MeasurementCompleteEventArgs() { Measurement = TakeMeasurements() });
            }
        }
        protected Measurement currentValue;
        protected TimeSpan measurementInterval;

        public class Measurement
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
            public override string ToString()
            {
                return "X=" + X + ",Y=" + Y + "Z=" + Z;
            }
        }
    }
}
