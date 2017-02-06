using Moq;
using Services;
using System;
using System.Linq;
using Xunit;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void ConsoleLogger_Exists()
        {
            var logr = new ConsoleLogger();
            logr.Log("Test msg.");

            Assert.True(true);
        }

        [Fact]
        public void QueueLogger_Exists()
        {
            var logr = new QueueLogger();
            logr.Log("Test msg.");

            Assert.True(true);
        }
        
        [Fact]
        public void QueueLogger_Implements_LogMethod()
        {
            IMessageLogger emptyLogr;

            var logr = new QueueLogger();
            logr.Log("Test msg.");

            Assert.True(true);
        }

        [Fact]
        public void QueueLogger_DerivesFromILogger()
        {
            IMessageLogger emptyLogr;

            var logr = new QueueLogger();
            logr.Log("Test msg.");

            Assert.True(logr is IMessageLogger);
        }

        [Fact]
        public void ConsoleLogger_DerivesFromILogger()
        {
            IMessageLogger emptyLogr;

            var logr = new ConsoleLogger();
            logr.Log("Test msg.");

            Assert.True(logr is IMessageLogger);
        }

        [Fact]
        public void Logger_TakesLogTypeInCtor()
        {
            var logger = new Logger(LogType.Console);
            
            Assert.True(true);
        }

        [Fact]
        public void Logger_TakesInjectedLoggerInCtor()
        {
            var logr = new ConsoleLogger();
            var logger = new Logger(logr);

            Assert.True(true);
        }



        // --- Moq tests ---
        
        [Fact]
        public void WhenInjectSpecificLoggerToCtor_VerifyLogrPropHasInjectedObject()
        {
            Mock<ConsoleLogger> mockConsole = new Mock<ConsoleLogger>();
            //Mock<Logger> mockLogger = new Mock<Logger>();
            var logger = new Logger(mockConsole.Object);

            //mockLogger.Verify(t => t.Log("test"));
            Assert.Equal(logger.Logr, mockConsole.Object);
        }

        [Fact]
        public void WhenPassingInConsoleLogTypeToCtor_VerifyLogrPropHasCorrectLoggerType()
        {
            Mock<Logger> mockLogger = new Mock<Logger>(LogType.Console);
            
            Assert.True(mockLogger.Object.Logr is ConsoleLogger);
        }

        [Fact]
        public void WhenPassingInQueueLogTypeToCtor_VerifyLogrPropHasCorrectLoggerType()
        {
            Mock<Logger> mockLogger = new Mock<Logger>(LogType.Queue);

            Assert.True(mockLogger.Object.Logr is QueueLogger);
        }
    }
}
