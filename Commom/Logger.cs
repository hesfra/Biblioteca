using System;

namespace Biblioteca.Commons.Logging;

public interface ILogger
{
    void Info(string message);
    void Warning(string message);
    void Error(string message, Exception? ex = null);
}

public class ConsoleLogger : ILogger

{
    private static readonly object _lock = new();
    public void Info(string message)
    {
         Write("INFO", ConsoleColor.Green, message);
    }

    public void Warning(string message)
    {
        Write("WARN", ConsoleColor.Yellow, message);
    }

    public void Error(string message, Exception? ex = null)
    {
         Write("ERROR", ConsoleColor.Red, $"{message} {ex?.Message}");
    }
     private void Write(string level, ConsoleColor color, string message)
    {
        lock (_lock)
        {
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            Console.ForegroundColor = color;
            Console.Write($"[{timestamp}] [{level}] ");
            Console.ResetColor();

            Console.WriteLine(message);
        }
    }
}