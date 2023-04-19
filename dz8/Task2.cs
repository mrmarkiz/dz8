using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz8
{
    internal class Task2
    {
        public static void Run()
        {
            Console.Write("Enter positive number to work with: ");
            uint.TryParse(Console.ReadLine(), out uint number);
            DecimalNumber decimalNumber = new DecimalNumber(number);
            uint choice;
            do
            {
                Console.WriteLine("Enter what to do(1 - show number, 2 - show binary, 3 - show octal number, 4 - hex number):");
                uint.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(decimalNumber.number);
                        break;
                    case 2:
                        Console.WriteLine(decimalNumber.ToBinaryNumber());
                        break;
                    case 3:
                        Console.WriteLine(decimalNumber.ToOctalNumber());
                        break;
                    case 4:
                        Console.WriteLine(decimalNumber.ToHexNumber());
                        break;
                }
            } while (choice != 0);
        }
    }

    struct DecimalNumber
    {
        public uint number;

        public DecimalNumber()
        {
            number = 0;
        }
        public DecimalNumber(uint num)
        {
            this.number = num;
        }

        public override string ToString()
        {
            return number.ToString();
        }

        public string ToBinaryNumber()
        {
            char[] result = new char[0];
            uint num = number;
            while (num > 1)
            {
                result = result.Append((char)(num % 2 + 48)).ToArray();
                num /= 2;
            }
            result = result.Append((char)(num + 48)).ToArray();
            result = result.Reverse().ToArray();
            return new string(result);
        }

        public string ToOctalNumber()
        {
            char[] result = new char[0];
            uint num = number;
            while (num > 8)
            {
                result = result.Append((char)(num % 8 + 48)).ToArray();
                num /= 8;
            }
            result = result.Append((char)(num + 48)).ToArray();
            result = result.Reverse().ToArray();
            return new string(result);
        }

        public string ToHexNumber()
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
            return new string(result);
        }
    }
}
