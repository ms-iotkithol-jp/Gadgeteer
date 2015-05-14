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
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");

            //// Comment in for testing SetDebugLED method
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

            //// Comment in for testing Color and Debug LEDs
            //LedTest();

            // Comment in for testing the button
            var peach = (IoTKitBoard)Mainboard;
            peach.Button.ButtonPressed += Button_ButtonPressed;
            peach.Button.ButtonReleased += Button_ButtonReleased;
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

                peach.PulseDebugLed();
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

        void Button_ButtonPressed(Algyan.Gadgeteer.Modules.Button sender, Algyan.Gadgeteer.Modules.Button.ButtonState state)
        {
            Mainboard.SetDebugLED(true);
        }

        void Button_ButtonReleased(Algyan.Gadgeteer.Modules.Button sender, Algyan.Gadgeteer.Modules.Button.ButtonState state)
        {
            Mainboard.SetDebugLED(false);
        }
    }
}
