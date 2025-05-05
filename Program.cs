/*
 * Everybody Loves Cards!
 * Ashani Li Peissigma, March 23 2025
 * Credits:
 * --- Unicode encoding (Library.cs lines 77-84)
 * --- Solution by Paul Sasik on Stackoverflow
 * --- https://stackoverflow.com/questions/5750203/how-to-write-unicode-characters-to-the-console
 */

using System.Reflection;

namespace Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            Console.Title = engine.Title;
            engine.Run();
        }
    }
}
