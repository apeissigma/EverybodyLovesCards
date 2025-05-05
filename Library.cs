using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal static class Library
    {
        //unicode characters
        public static char SpadeChar = '\u2660';
        public static char HeartChar = '\u2665';
        public static char DiamondChar = '\u2666';
        public static char ClubChar = '\u2663';
        public static char TenChar = '\u2491';


        public static void Print(string s)
        {
            Console.WriteLine(s);
        }

        public static void PrintInline(string s)
        {
            Console.Write(s);
        }

        public static string GetInputString()
        {
            return Console.ReadLine().ToString();
        }

        public static int GetInputInt()
        {
            int converted = 0;
            bool isConvertable = false; 

            while (!isConvertable)
            {
                var input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    converted = result; 
                    isConvertable = true;
                }
                else
                {
                    Print("\n > Please enter a valid number...\n");
                }
            }
            return converted;
        }

        public static void Wait(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Print($"\n > Press any key to {s}...\n");

            Console.ResetColor();
            Console.ReadKey();
        }

        public static int RandomInt(int i)
        {
            Random random = new Random();
            return random.Next(i);
        }

        public static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static void EnableUnicodeEncoding()
        {
            /*
             * Unicode encoding (Solution by Paul Sasik on Stackoverflow): 
             * https://stackoverflow.com/questions/5750203/how-to-write-unicode-characters-to-the-console
             */
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

    }
}
