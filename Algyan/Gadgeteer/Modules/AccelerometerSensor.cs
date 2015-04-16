using System;
using Microsoft.SPOT;

namespace Algyan.Gadgeteer.Modules
{
    public abstract class AccelerometerSensor
    {
        public TimeSpan MeasurementInterval
        {
            get { return measurementInterval; }
            set { measurementInterval = value; }
        }

        public abstract void StartTakingMeasurements();
        public abstract void StopTakingMeasurements();
        public abstract Measurement TakeMeasurements();

        public event MeasurementCompleteEventHandler MeasuremntComplete;
        public delegate void MeasurementCompleteEventHandler(AccelerometerSensor sender, MeasurementCompleteEventArgs e);

        public class MeasurementCompleteEventArgs : EventArgs
        {
            public Measurement Measurement { get; set; }
            public override string ToString()
            {
                return Measurement.ToString();
            }
        }

        protected void OnMesarementComplete()
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
