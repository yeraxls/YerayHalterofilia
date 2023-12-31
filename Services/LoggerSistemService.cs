﻿using db;

namespace YerayHalterofilia.Services
{
    public class LoggerSistemService : ILoggerSistemService
    {
        public void Write(string action, string message, bool itsError = false)
        {
            var exists = Directory.Exists("logs");
            if (!exists)
                Directory.CreateDirectory("logs");
            using (StreamWriter w = File.AppendText("logs/log.txt"))
            {
                Log(message, w, itsError);
            }
        }
        private static void Log(string logMessage, TextWriter w, bool itsError)
        {
            w.Write(String.Format("\r\nLog {0} Entry : ", itsError ? "error" : "info"));
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }
    }
}
