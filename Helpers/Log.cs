
using System;

namespace task_cli.Helpers
{
    public static class Log
    {
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[INFO]");
            Console.ResetColor();
            Console.WriteLine($" {message}");
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[ERROR]");
            Console.ResetColor();
            Console.WriteLine($" {message}");
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"[WARNING]");
            Console.ResetColor();
            Console.WriteLine($" {message}");
        }

        public static void Debug(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[DEBUG]");
            Console.ResetColor();
            Console.WriteLine($" {message}");
        }
    }
}