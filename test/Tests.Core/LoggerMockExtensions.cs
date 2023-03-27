using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.Core
{
    public static class LoggerMockExtensions
    {
        public static Mock<ILogger<T>> VerifyDebug<T>(this Mock<ILogger<T>> logger, Func<Times> times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Debug),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v,t) => true)), times);
            return logger;
        }

        public static Mock<ILogger<T>> VerifyDebug<T>(this Mock<ILogger<T>> logger, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => string.Compare(v.ToString(), expectedMessage, StringComparison.Ordinal) == 0;
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Debug),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v,t) => state(v,t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger<T>> VerifyInformation<T>(this Mock<ILogger<T>> logger, Func<Times> times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger<T>> VerifyInformation<T>(this Mock<ILogger<T>> logger, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => string.Compare(v.ToString(), expectedMessage, StringComparison.Ordinal) == 0;
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger<T>> VerifyWarning<T>(this Mock<ILogger<T>> logger, Func<Times> times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Warning),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger<T>> VerifyWarning<T>(this Mock<ILogger<T>> logger, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => string.Compare(v.ToString(), expectedMessage, StringComparison.Ordinal) == 0;
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Warning),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger<T>> VerifyError<T>(this Mock<ILogger<T>> logger, Func<Times> times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger<T>> VerifyError<T>(this Mock<ILogger<T>> logger, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => string.Compare(v.ToString(), expectedMessage, StringComparison.Ordinal) == 0;
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger<T>> VerifyCritical<T>(this Mock<ILogger<T>> logger, Func<Times> times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Critical),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger<T>> VerifyCritical<T>(this Mock<ILogger<T>> logger, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => string.Compare(v.ToString(), expectedMessage, StringComparison.Ordinal) == 0;
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Critical),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger> VerifyDebug(this Mock<ILogger> logger, Func<Times> times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Debug),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger> VerifyDebug(this Mock<ILogger> logger, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => string.Compare(v.ToString(), expectedMessage, StringComparison.Ordinal) == 0;
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Debug),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger> VerifyInformation(this Mock<ILogger> logger, Func<Times> times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger> VerifyInformation(this Mock<ILogger> logger, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => string.Compare(v.ToString(), expectedMessage, StringComparison.Ordinal) == 0;
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger> VerifyWarning(this Mock<ILogger> logger, Func<Times> times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Warning),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger> VerifyWarning(this Mock<ILogger> logger, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => string.Compare(v.ToString(), expectedMessage, StringComparison.Ordinal) == 0;
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Warning),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger> VerifyError(this Mock<ILogger> logger, Func<Times> times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger> VerifyError(this Mock<ILogger> logger, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => string.Compare(v.ToString(), expectedMessage, StringComparison.Ordinal) == 0;
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger> VerifyCritical(this Mock<ILogger> logger, Func<Times> times)
        {
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Critical),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }

        public static Mock<ILogger> VerifyCritical(this Mock<ILogger> logger, string expectedMessage, Func<Times> times)
        {
            Func<object, Type, bool> state = (v, t) => string.Compare(v.ToString(), expectedMessage, StringComparison.Ordinal) == 0;
            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Critical),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), times);
            return logger;
        }
    }
}