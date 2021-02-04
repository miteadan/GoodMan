using Iot.Device.BrickPi3.Sensors;
using Iot.Device.CharacterLcd;
using Iot.Device.Pcx857x;
using System;
using System.Device.Gpio;
using System.Device.I2c;
using System.Linq;
using System.Threading;

namespace GoodMan
{
    class Program
    {
        static void Main(string[] args)
        {
            var i2c = I2cDevice.Create(new(busId: 1, deviceAddress: 0x27));
            using var lcd = new Lcd1602(0, 2, new[] { 4, 5, 6, 7 }, 3, 1, 1, new(PinNumberingScheme.Logical, new Pcf8574(i2c))) { DisplayOn = true };

            lcd.Write(args.FirstOrDefault() ?? "Hello World!");
            lcd.SetCursorPosition(0, 1);
            lcd.Write(args.Skip(1).FirstOrDefault() ?? "Hi!");
        }
    }
}
