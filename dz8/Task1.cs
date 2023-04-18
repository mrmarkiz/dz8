using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace dz8
{
    public class Task1
    {
        public static void Run()
        {
            Vector3D vector1, vector2, result = new Vector3D();
            int x, y, z;
            Console.Write("Enter first vector(x y z): ");
            string[] input = Console.ReadLine().Split(' ');
            while (input.Length < 3)
            {
                input = input.Append("0").ToArray();
            }
            int.TryParse(input[0], out x);
            int.TryParse(input[1], out y);
            int.TryParse(input[2], out z);
            vector1 = new Vector3D(x, y, z);
            Console.Write("Enter second vector(x y z): ");
            input = Console.ReadLine().Split(' ');
            while (input.Length < 3)
            {
                input = input.Append("0").ToArray();
            }
            int.TryParse(input[0], out x);
            int.TryParse(input[1], out y);
            int.TryParse(input[2], out z);
            vector2 = new Vector3D(x, y, z);
            int choice;
            do
            {
                Console.WriteLine("Enter what to do(1 - show vectors, 2 - multiply vector on number, 3 - add vectors, 4 - substract vectors):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Vector1: {vector1}");
                        Console.WriteLine($"Vector2: {vector2}");
                        break;
                    case 2:
                        Console.WriteLine("Enter which vector to multiply(first, second):");
                        string vector = Console.ReadLine();
                        int number;
                        Console.Write("Enter number to multiply on: ");
                        int.TryParse(Console.ReadLine(), out number);
                        if (vector == "first")
                        {
                            result = vector1 * number;
                        }
                        else if (vector == "second")
                        {
                            result = vector2 * number;
                        }
                        Console.WriteLine($"Result vector: {result}");
                        break;
                    case 3:
                        result = vector1 + vector2;
                        Console.WriteLine($"Result vector: {result}");
                        break;
                    case 4:
                        result = vector1 - vector2;
                        Console.WriteLine($"Result vector: {result}");
                        break;
                }
            } while (choice != 0);
        }
    }

    public struct Vector3D
    {
        public int x;
        public int y;
        public int z;

        public Vector3D()
        {
            x = 0; y = 0; z = 0;
        }

        public Vector3D(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public override string ToString()
        {
            return $"{x};{y};{z}";
        }

        public static Vector3D operator *(Vector3D vector, int num)
        {
            vector.x *= num;
            vector.y *= num;
            vector.z *= num;
            return vector;
        }

        public static Vector3D operator *(int num, Vector3D vector)
        {
            vector.x *= num;
            vector.y *= num;
            vector.z *= num;
            return vector;
        }
        
        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            Vector3D result = new Vector3D(vector1.x + vector2.x, vector1.y + vector2.y, vector1.z + vector2.z);
            return result;
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            Vector3D result = new Vector3D(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
            return result;
        }

    }
}
