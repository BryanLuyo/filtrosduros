using System.IO;
using System;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using System.Threading;

public sealed class LoggerService : IDisposable
{
    private static readonly object instanceLock = new object();
    private static LoggerService _instance;
    private readonly Queue<string> logQueue = new Queue<string>();
    private readonly object logLock = new object();
    private readonly Thread loggingThread;
    private string rootDirectory;
    private string currentLogFileName;
    private bool disposed;
    private bool keepRunning;

    public static LoggerService Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (instanceLock)
                {
                    if (_instance == null)
                        _instance = new LoggerService();
                }
            }
            return _instance;
        }
    }

    private LoggerService()
    {
        rootDirectory = Path.Combine(ConfigurationManager.AppSettings["Path"] ?? "Logs");
        Directory.CreateDirectory(rootDirectory);
        UpdateLogFileName();

        keepRunning = true;
        loggingThread = new Thread(ProcessLogQueue)
        {
            IsBackground = true
        };
        loggingThread.Start();
    }

    private void UpdateLogFileName()
    {
        string currentDate = DateTime.Now.ToString("yyyyMMdd");
        currentLogFileName = Path.Combine(rootDirectory, "PreEvaluacionPC_" + currentDate + ".log");
    }

    public void LoggerSaveTramas<T>(T data, string message, string canal)
    {
        string logEntry = string.Format("[{0}] {1}\r\n{2}", DateTime.Now.ToString("HH:mm:ss"), message, data);
        lock (logLock)
        {
            logQueue.Enqueue(logEntry); 
            Monitor.Pulse(logLock); 
        }
    }

    private void ProcessLogQueue()
    {
        while (keepRunning)
        {
            string logEntry = null;

            lock (logLock)
            {
                while (logQueue.Count == 0 && keepRunning)
                {
                    Monitor.Wait(logLock);
                }

                if (logQueue.Count > 0)
                {
                    logEntry = logQueue.Dequeue();
                }
            }

            if (logEntry != null)
            {
                WriteLog(logEntry);
            }
        }

        lock (logLock)
        {
            while (logQueue.Count > 0)
            {
                WriteLog(logQueue.Dequeue());
            }
        }
    }

    private void WriteLog(string logEntry)
    {
        try
        {
            using (var writer = new StreamWriter(currentLogFileName, true, Encoding.UTF8))
            {
                writer.WriteLine(logEntry);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error al escribir en el log: " + ex.Message);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                lock (logLock)
                {
                    keepRunning = false;
                    Monitor.PulseAll(logLock);
                }

                if (loggingThread != null)
                {
                    loggingThread.Join();
                }
            }
            disposed = true;
        }
    }
}
//public sealed class LoggerService : IDisposable
//{
//    private static readonly Lazy<LoggerService> _instance = new Lazy<LoggerService>(() => new LoggerService());
//    private static readonly object lockObject = new object();
//    private string rootDirectory;
//    private string currentLogFileName;
//    private bool disposed;

//    public static LoggerService Instance
//    {
//        get { return _instance.Value; }
//    }

//    private LoggerService()
//    {
//        try
//        {
//            rootDirectory = Path.Combine(ConfigurationManager.AppSettings["Path"] ?? "Logs");
//            if (!Directory.Exists(rootDirectory))
//            {
//                Directory.CreateDirectory(rootDirectory); // Crea el directorio si no existe
//            }
//            UpdateLogFileName();
//        }
//        catch (Exception ex)
//        {
//            // Manejar errores relacionados con el directorio
//            Console.WriteLine(string.Format("Error al inicializar LoggerService: {0}", ex.Message));
//        }
//    }

//    private void UpdateLogFileName()
//    {
//        string currentDate = DateTime.Now.ToString("yyyyMMdd");
//        currentLogFileName = Path.Combine(rootDirectory, string.Format("PreEvaluacionPC_{0}.log", currentDate));
//    }

//    public void LoggerSaveTramas(string data, string message, string canal)
//    {
//        string logEntry = string.Format("[{0:HH:mm:ss}] {1}\r\n{2}", DateTime.Now, message, data);

//        lock (lockObject)
//        {
//            UpdateLogFileName(); // Asegurar archivo actualizado
//            WriteLog(logEntry);
//        }
//    }

//    public void LoggerSaveTramas<T>(T data, string message, string canal)
//    {
//        string serializedData = JsonConvert.SerializeObject(data);
//        string logEntry = string.Format("[{0:HH:mm:ss}] {1}\r\n{2}", DateTime.Now, message, serializedData);

//        lock (lockObject)
//        {
//            UpdateLogFileName(); // Asegurar archivo actualizado
//            WriteLog(logEntry);
//        }
//    }

//    private void WriteLog(string logEntry)
//    {
//        try
//        {
//            // Uso de `using` para manejar el archivo dinámicamente y prevenir bloqueos
//            using (var writer = new StreamWriter(currentLogFileName, true, Encoding.UTF8))
//            {
//                writer.WriteLine(logEntry);
//            }
//        }
//        catch (IOException ex)
//        {
//            // Manejo de errores al escribir en el archivo
//            Console.WriteLine(string.Format("Error al escribir en el log: {0}", ex.Message));
//        }
//    }

//    public void Dispose()
//    {
//        Dispose(true);
//        GC.SuppressFinalize(this);
//    }

//    private void Dispose(bool disposing)
//    {
//        if (!disposed)
//        {
//            if (disposing)
//            {
//                // Liberar recursos si fuese necesario
//            }
//            disposed = true;
//        }
//    }
//}



//public partial class LoggerService
//{
//    private static LoggerService _instance;
//    private StreamWriter objReader;
//    private string direccionFolder = Path.Combine(ConfigurationManager.AppSettings["Path"].ToString());
//    private string fileFolder = DateTime.Now.ToString("yyyyMMdd");
//    private string root;
//    private string file_name = "PreEvaluacionPC";
//    private string FullPath;
//    private bool disposed;

//    public static LoggerService Instance{
//        get 
//        {
//            if (_instance == null)
//                _instance = new LoggerService();
//            return _instance;
//        }
//    }
//    public LoggerService()
//    {
//        root = Path.Combine(direccionFolder, fileFolder);
//        if (!Directory.Exists(root))
//            Directory.CreateDirectory(root);
//        FullPath = root + @"\" + file_name;
//        if(objReader == null)
//            objReader = new StreamWriter(FullPath,true);

//    }
//    ~LoggerService()
//    {
//        this.Dispose(false);
//    }
//    public void Dispose()
//    {
//        this.Dispose(true);
//        GC.SuppressFinalize(this);
//    }
//    protected virtual void Dispose(bool disposing)
//    {
//        if (!disposed)
//        {
//            if (disposing)
//            {
//                // Dispose managed resources here.
//            }
//            // Dispose unmanaged resources here.
//        }
//        disposed = true;
//    }
//    public void LoggerSaveTramas(string data, string message, string canal)
//    {
//        string line = "[{0}]{1}{2}{3}";
//        line = string.Format(line, DateTime.Now.ToString("HH:mm:ss"), message, "\r\n", data);
//        objReader.Write(line + "\r\n");
//    }

//    public void LoggerSaveTramas<T>(T data, string message, string canal)
//    {
//        string line = "[{0}]{1}{2}{3}";
//        line = string.Format(line, DateTime.Now.ToString("HH:mm:ss"), message, "\r\n", JsonConvert.SerializeObject(data));
//        objReader.Write(line + "\r\n");
//    }

//}
