using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public interface IMessageLogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : IMessageLogger
    {
        public void Log(string message)
        {
            // Do some work here.
            Console.WriteLine(message);
        }
    }

    public class QueueLogger : IMessageLogger
    {
        public void Log(string message)
        {
            // Do some work here.
        }
    }


    /// <summary>
    /// This class is designed to perform a basic logging function.
    /// In the future, we might want to expand our logging capabilities. 
    /// 
    /// Currently, this class doesn't follow SOLID and would require too much modification to extext. 
    /// It violates the Open Close Principle. 
    /// 
    /// Please refactor this method and provide tests in Services.UnitTests.LoggerTests.LogShould.
    /// 
    /// 
    /// Hint:
    /// 
    /// public class ConsoleLogger : IMessageLogger {}
    /// public class QueueLogger : IMessageLogger {}
    /// </summary>
    public class Logger
    {
        public IMessageLogger Logr{ get; set; }

        public Logger(IMessageLogger byoLogr)
        {
            Logr = byoLogr;
        }

        public Logger(LogType logType)
        {
            switch (logType)
            {
                case LogType.Console:
                    Logr = new ConsoleLogger();
                    break;

                case LogType.Queue:
                    Logr = new QueueLogger();
                    break;
            }
        }

        public void Log(string message)
        {
            Logr.Log(message);
            
        }
    }


    public enum LogType
    {
        Console,
        Queue
    }
}
