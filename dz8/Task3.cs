using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace dz8
{
    internal class Task3
    {
        public static void Run()
        {
            byte r, g, b;
            Console.Write("Enter color in RGB(red green blue) format: ");
            string[] input = Console.ReadLine().Split(' ', ',');
            while (input.Length < 3)
                input = input.Append("0").ToArray();
            byte.TryParse(input[0], out r);
            byte.TryParse(input[1], out g);
            byte.TryParse(input[2], out b);
            RGB color = new RGB(r, g, b);
            int choice;
            do
            {
                Console.WriteLine("Enter what to do(1 - show RGB, 2 - show HEX, 3 - show HSL, 4 - show CMYK):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Color: {color}");
                        break;
                    case 2:
                        Console.WriteLine($"Color: {color.ToHex()}");
                        break;
                    case 3:
                        Console.WriteLine($"Color: {color.ToHSL()}");
                        break;
                    case 4:
                        Console.WriteLine($"Color: {color.ToCMYK()}");
                        break;
                }
            } while (choice != 0);
        }
    }

    public struct RGB
    {
        byte red;
        byte green;
        byte blue;

        public RGB()
        {
            red = 0;
            green = 0;
            blue = 0;
        }
        public RGB(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
        public override string ToString()
        {
            return $"{red},{green},{blue}";
        }

        public string ToHex()
        {
            string result = "#";
            return result + ToHexNumber(red) + ToHexNumber(green) + ToHexNumber(blue);
        }
        private string ToHexNumber(uint number)
        {
            char[] result = new char[0];
            uint num = number;
            while (num > 16)
            {
                if (num % 16 < 10)
                    result = result.Append((char)(num % 16 + 48)).ToArray();
                else
                    result = result.Append((char)(num % 16 + 55)).ToArray();
                num /= 16;
            }
            if (num < 10)
                result = result.Append((char)(num + 48)).ToArray();
            else
                result = result.Append((char)(num + 55)).ToArray();
            result = result.Reverse().ToArray();
            if (result.Length != 2) 
            {
                result = result.Append(' ').ToArray();
            }
            return new string(result);
        }

        public string ToHSL()
        {
            double r = red / 255.0, g = green / 255.0, b = blue / 255.0;
            double max = Math.Max(Math.Max(r, g), b);
            double min = Math.Min(Math.Min(r, g), b);
            double lum = (max + min) / 2, hue, sat;
            if (max == min)
            {
                hue = 0;
                sat = 0;
            }
            else
            {
                double c = max - min;
                sat = c / (1 - Math.Abs(2 * lum - 1));
                hue = ToHue();
            }
            sat *= 100;
            lum *= 100;
            return $"{(int)hue}, {Math.Round(sat)}%, {Math.Round(lum)}%";
        }
        private double ToHue()
        {
            double r = red / 255.0, g = green / 255.0, b = blue / 255.0;
            double max = Math.Max(Math.Max(r, g), b);
            double min = Math.Min(Math.Min(r, g), b);
            double c = max - min, hue;
            if (max == min)
            {
                hue = 0;
            }
            else
            {
                double segment, shift;
                if (max == r)
                {
                    segment = (g - b) / c;
                    shift = 0 / 60;
                    if (segment < 0)
                    {
                        shift = 360 / 60;
                    }
                }
                else if (max == g)
                {
                    segment = (b - r) / c;
                    shift = 120 / 60;
                }
                else
                {
                    segment = (r - g) / c;
                    shift = 240 / 60;
                }
                hue = segment + shift;
            }
            return hue * 60;
        }

        public string ToCMYK()
        {
            double r = red / 255.0, g = green / 255.0, b = blue / 255.0;
            double K = 1 - Math.Max(Math.Max(r, g), b);
            double C = (1 - r - K) / (1 - K);
            double M = (1 - g - K) / (1 - K);
            double Y = (1 - b - K) / (1 - K);
            K *= 100; C *= 100;M *= 100; Y *= 100;
            return $"{Math.Round(C)}%, {Math.Round(M)}%, {Math.Round(Y)}%, {Math.Round(K)}%";
        }
    }
}
