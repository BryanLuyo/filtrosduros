
using System.IO;
using System;
using System.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Utils.Bantotal
{
    public static class LoggerBT
    {
        private static readonly object lockObject = new object();  
        private static Queue<string> logQueue = new Queue<string>();
        private static bool isLogging = false;  

        public static void LoggerSaveTramas(string data, string file_name, string message, string canal)
        {
            string line = "[{0}]{1}{2}{3}";
            line = string.Format(line, DateTime.Now.ToString("HH:mm:ss"), message, "\r\n", data);

            lock (logQueue)
            {
                logQueue.Enqueue(line);
            }

            if (!isLogging)
            {
                Task.Run(() => ProcessLogQueue(file_name, canal));
            }
        }

        public static void LoggerSaveTramas<T>(T data, string file_name, string message, string canal)
        {
            string serializedData = JsonConvert.SerializeObject(data);

            string line = "[{0}]{1}{2}{3}";
            line = string.Format(line, DateTime.Now.ToString("HH:mm:ss"), message, "\r\n", serializedData);

            lock (logQueue)
            {
                logQueue.Enqueue(line);
            }

            if (!isLogging)
            {
                Task.Run(() => ProcessLogQueue(file_name, canal));
            }
        }

        private static void ProcessLogQueue(string file_name, string canal)
        {
            isLogging = true;

            string direccionFolder = Path.Combine(ConfigurationManager.AppSettings["Path"], canal);
            string fileFolder = DateTime.Now.ToString("yyyyMMdd");
            string root = Path.Combine(direccionFolder, fileFolder);

            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            string fullPath = Path.Combine(root, file_name);

            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
                while (logQueue.Count > 0)
                {
                    string logEntry;

                    lock (logQueue)
                    {
                        logEntry = logQueue.Dequeue();
                    }

                    writer.WriteLine(logEntry);
                }
            }

            isLogging = false; 
        }

        //public static class LoggerBT
        //{

        //    public static void LoggerSaveTramas(string data, string file_name, string message, string canal)
        //    {
        //        StreamWriter objReader;
        //        string direccionFolder = Path.Combine(ConfigurationManager.AppSettings["Path"], canal);
        //        string fileFolder = DateTime.Now.ToString("yyyyMMdd");
        //        string root = Path.Combine(direccionFolder, fileFolder);
        //        if (!Directory.Exists(root))
        //            Directory.CreateDirectory(root);

        //        string line = "[{0}]{1}{2}{3}";
        //        line = string.Format(line, DateTime.Now.ToString("HH:mm:ss"), message, "\r\n", data);
        //            string FullPath = root + @"\" + file_name;
        //            objReader = new StreamWriter(FullPath, true);
        //            objReader.Write(line + "\r\n");

        //        objReader.Close();

        //    }

        //    public static void LoggerSaveTramas<T>(T data, string file_name, string message, string canal)
        //    {
        //        StreamWriter objReader;
        //        string direccionFolder = Path.Combine(ConfigurationManager.AppSettings["Path"], canal);
        //        string fileFolder = DateTime.Now.ToString("yyyyMMdd");
        //        string root = Path.Combine(direccionFolder, fileFolder);
        //        if (!Directory.Exists(root))
        //            Directory.CreateDirectory(root);


        //        string line = "[{0}]{1}{2}{3}";
        //        line = string.Format(line, DateTime.Now.ToString("HH:mm:ss"), message, "\r\n", JsonConvert.SerializeObject(data));
        //        string FullPath = root + @"\" + file_name;
        //        objReader = new StreamWriter(FullPath, true);
        //        objReader.Write(line + "\r\n");


        //        objReader.Close();

        //    }
        //}
    }
}
