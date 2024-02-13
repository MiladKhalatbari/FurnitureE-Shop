using FurnitureOnlineShop.Application.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Infrastructure.LogService
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }
        public void Log(string message, params object[] args)
        {
            _logger.LogDebug(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);    
        }

        public void LogInformation(string message, params object[] args)
        {

            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);  
        }
    }
}
