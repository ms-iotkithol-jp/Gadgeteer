using System;
using System.Collections;
using System.Threading;
using Algyan.Gadgeteer;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;

namespace GrPeachTestApp
{
    public partial class Program
    {
        static void InitializeMainboard()
        {
            Mainboard = new Algyan.Gadgeteer.GR_PEACH_IoT_Kit();
        }

        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            /*******************************************************************************************
            Modules added in the Program.gadgeteer designer view are used by typing 
            their name followed by a period, e.g.  button.  or  camera.
            
            Many modules generate useful events. Type +=<tab><tab> to add a handler to an event, e.g.:
                button.ButtonPressed +=<tab><tab>
            
            If you want to do something periodically, use a GT.Timer and handle its Tick event, e.g.:
                GT.Timer timer = new GT.Timer(1000); // every second (1000ms)
                timer.Tick +=<tab><tab>
                timer.Start();
            *******************************************************************************************/


            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");

            //var isLightOn = false;
            //(new Thread(() =>
            //{
            //    while (true)
            //    {
            //        isLightOn = !isLightOn;
            //        Mainboard.SetDebugLED(isLightOn);
            //        Thread.Sleep(1000);
            //    }
            //})).Start();

            LedTest();
        }

        private void LedTest()
        {
            var peach = (IoTKitBoard) Mainboard;

            while (true)
            {
                Mainboard.SetDebugLED(true);
                Thread.Sleep(1000);
                Mainboard.SetDebugLED(false);
                Thread.Sleep(1000);

                peach.PulseDebugLed(100, 5);
                Thread.Sleep(1000);

                peach.RedLed.SetLed(true);
                Thread.Sleep(1000);
                peach.RedLed.SetLed(false);
                Thread.Sleep(1000);

                peach.GreenLed.SetLed(true);
                Thread.Sleep(1000);
                peach.GreenLed.SetLed(false);
                Thread.Sleep(1000);

                peach.BlueLed.SetLed(true);
                Thread.Sleep(1000);
                peach.BlueLed.SetLed(false);
                Thread.Sleep(1000);
            }
        }
    }
}
