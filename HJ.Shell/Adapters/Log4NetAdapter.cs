using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Microsoft.Practices.Prism.Logging;


namespace HJ.Shell.Adapters
{
    class Log4NetAdapter : ILoggerFacade
    {
        #region Fields

        // Member variables
        private readonly ILog _logger = LogManager.GetLogger(typeof(Log4NetAdapter)); 

        #endregion

        public Log4NetAdapter()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        #region ILoggerFacade Members

        /// <summary>
        /// Writes a log message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="category">The message category.</param>
        /// <param name="priority">Not used by Log4Net; pass Priority.None.</param>
        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    _logger.Debug(message);
                    break;
                case Category.Warn:
                    _logger.Warn(message);
                    break;
                case Category.Exception:
                    _logger.Error(message);
                    break;
                case Category.Info:
                    _logger.Info(message);
                    break;
            }
        }

        #endregion
    }
}
