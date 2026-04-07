using System;
using System.IO;

namespace LocalShare.Core
{
    public static class Logger
    {
        private static string logFile = "app.log";

        public static void Log(string message)
        {
            string log = $"{DateTime.Now} [INFO] {message}";
            Write(log);
        }

        public static void Error(string message)
        {
            string log = $"{DateTime.Now} [ERROR] {message}";
            Write(log);
        }

        private static void Write(string text)
        {
            try
            {
                File.AppendAllText(logFile, text + Environment.NewLine);
            }
            catch
            {
                // éviter crash si problème écriture
            }
        }
    }
}