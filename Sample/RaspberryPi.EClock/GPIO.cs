using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Text;
using System.Threading;

namespace RaspberryPi.EClock
{
    public class Clock
    {
        private const int PinA = 26;
        private const int PinB = 19;
        private const int PinC = 22;
        private const int PinD = 6;
        private const int PinE = 17;
        private const int PinF = 11;
        private const int PinG = 9;
        private const int PinDP = 10;

        private const int PinDIGIT1 = 4;
        private const int PinDIGIT2 = 16;
        private const int PinDIGIT3 = 20;
        private const int PinDIGIT4 = 21;

        private GpioController controller = new GpioController();

        public Clock()
        {
            controller.OpenPin(PinA, PinMode.Output);
            controller.OpenPin(PinB, PinMode.Output);
            controller.OpenPin(PinC, PinMode.Output);
            controller.OpenPin(PinD, PinMode.Output);
            controller.OpenPin(PinE, PinMode.Output);
            controller.OpenPin(PinF, PinMode.Output);
            controller.OpenPin(PinG, PinMode.Output);
            controller.OpenPin(PinDP, PinMode.Output);
            controller.OpenPin(PinDIGIT1, PinMode.Output);
            controller.OpenPin(PinDIGIT2, PinMode.Output);
            controller.OpenPin(PinDIGIT3, PinMode.Output);
            controller.OpenPin(PinDIGIT4, PinMode.Output);
        }
        public void ShowTime(DateTime time)
        {
            Thread.Sleep(5);
            ShowDigit(1, time.Hour/10);
            Thread.Sleep(5);
            ShowDigit(2, time.Hour % 10);
            Thread.Sleep(5);
            ShowDigit(3, time.Second / 10);
            Thread.Sleep(5);
            ShowDigit(4, time.Second % 10);
        }

        public void ShowDigit(int left, int num)
        {
            this.Output(PinDIGIT1);
            this.Output(PinDIGIT2);
            this.Output(PinDIGIT3);
            this.Output(PinDIGIT4);

            var showDotPoint = left != 2;
            if (num == 0)
            {
                Output(PinA);
                Output(PinB);
                Output(PinC);
                Output(PinD);
                Output(PinE);
                Output(PinF);
                Output(PinG, true);
            }
            else if (num == 1)
            {
                Output(PinA, true);
                Output(PinB);
                Output(PinC);
                Output(PinD, true);
                Output(PinE, true);
                Output(PinF, true);
                Output(PinG, true);
            }
            else if (num == 2)
            {
                Output(PinA);
                Output(PinB);
                Output(PinC, true);
                Output(PinD);
                Output(PinE);
                Output(PinF, true);
                Output(PinG);
            }
            else if (num == 3)
            {
                Output(PinA);
                Output(PinB);
                Output(PinC);
                Output(PinD);
                Output(PinE, true);
                Output(PinF, true);
                Output(PinG);
            }
            else if (num == 4)
            {
                Output(PinA, true);
                Output(PinB);
                Output(PinC);
                Output(PinD, true);
                Output(PinE, true);
                Output(PinF);
                Output(PinG);
            }
            else if (num == 5)
            {
                Output(PinA);
                Output(PinB, true);
                Output(PinC);
                Output(PinD);
                Output(PinE, true);
                Output(PinF);
                Output(PinG);
            }
            else if (num == 6)
            {
                Output(PinA);
                Output(PinB, true);
                Output(PinC);
                Output(PinD);
                Output(PinE);
                Output(PinF);
                Output(PinG);
            }
            else if (num == 7)
            {
                Output(PinA);
                Output(PinB);
                Output(PinC);
                Output(PinD, true);
                Output(PinE, true);
                Output(PinF, true);
                Output(PinG, true);
            }
            else if (num == 8)
            {
                Output(PinA);
                Output(PinB);
                Output(PinC);
                Output(PinD);
                Output(PinE);
                Output(PinF);
                Output(PinG);
            }
            else if (num == 9)
            {
                Output(PinA);
                Output(PinB);
                Output(PinC);
                Output(PinD);
                Output(PinE, true);
                Output(PinF);
                Output(PinG);
            }

            Output(PinDP, showDotPoint);
            if (left == 1)
                Output(PinDIGIT1, true);
            if (left == 2)
                Output(PinDIGIT2, true);
            if (left == 3)
                Output(PinDIGIT3, true);
            if (left == 4)
                Output(PinDIGIT4, true);

        }

        private void Output(int pinNumber, bool high = false)
        {
            if (!this.controller.IsPinOpen(pinNumber))
            {
                this.controller.OpenPin(pinNumber, PinMode.Output);
            }
            controller.Write(pinNumber, high ? PinValue.High : PinValue.Low);
        }
    }
}
