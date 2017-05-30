using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Encapsulation
{
    class Box
    {
        public Box(decimal length, decimal width, decimal height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public decimal VolumeMethod()
        {
            decimal volume = this.Length * this.Height * this.Width;

            return volume;
        }

        public decimal LateralSurfaceMethod()
        {
            decimal lateral = 2 * this.Length * this.Height + 2 * this.Width * this.Height;

            return lateral;
        }

        public decimal SurfaceAreaMethod()
        {
            decimal area = 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Height * this.Width;

            return area;
        }
    }

    public class ClassBox
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            List<decimal> arguments = new List<decimal>();
            for (int i = 0; i < 3; i++)
            {
                decimal value = decimal.Parse(Console.ReadLine());
                arguments.Add(value);
            }

            decimal length = arguments[0];
            decimal widht = arguments[1];
            decimal height = arguments[2];

            Box box = new Box(length, widht, height);

            Console.WriteLine($"Surface Area - {box.SurfaceAreaMethod():F2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceMethod():F2}");
            Console.WriteLine($"Volume - {box.VolumeMethod():F2}");
        }
    }
}