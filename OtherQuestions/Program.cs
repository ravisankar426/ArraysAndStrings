using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertStringToInt("123"));
            Console.Read();
        }

        public static int ConvertStringToInt(string str)
        {
            char[] chars = str.ToCharArray();
            int result = 0;
            int counter = 0;
            int ascii;

            for (int i= chars.Length-1;i >= 0;i--) {
                ascii = (int)chars[i];
                if (ascii < 48 || ascii > 57) return 0;
                else {
                    result = result + (int)Math.Pow(10, counter)* GetNumberFromASCII(ascii);
                }
                counter++;
            }

            return result;
        }

        public static int GetNumberFromASCII(int ascii) {
            int number = -1;
            switch (ascii) {
                case 48:number = 0;break;
                case 49: number = 1; break;
                case 50: number = 2; break;
                case 51: number = 3; break;
                case 52: number = 4; break;
                case 53: number = 5; break;
                case 54: number = 6; break;
                case 55: number = 7; break;
                case 56: number = 8; break;
                case 57: number = 9; break;
                default: number=-1;break;
            }
            return number;
        }
    }
}
