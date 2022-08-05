using System;
using System.Diagnostics;
using System.IO;
using BusinessFramework.Contracts;
using BusinessFramework.Contracts.Utils;

using IOwinLogger = Microsoft.Owin.Logging.ILogger;

namespace Karelia.WebApiServer
{
    internal sealed class OwinLogger : ILogger
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public OwinLogger(IOwinLogger owinLog)
        {
            OwinLog = owinLog;
        }

        private IOwinLogger OwinLog { get; set; }

        public void Write(TraceEventType traceEventType, Exception exc, string message, params object[] args)
        {
            try
            {
                string fullMessage;
                if (args != null && args.Length > 0)
                {
                    try
                    {
                        fullMessage = string.Format(message, args);
                    }
                    catch (Exception exception)
                    {
                        OwinLog.WriteCore(TraceEventType.Error, 0, exception.Message, exception, GetMessage);

                        for (Int32 i = 0; i < args.Length; i++)
                        {
                            OwinLog.WriteCore(traceEventType, 0, $"args[{i}]: {args[i]}", null, GetMessage);
                        }

                        fullMessage = message;
                    }
                }
                else
                {
                    fullMessage = message;
                }

                OwinLog.WriteCore(traceEventType, 0, fullMessage, exc, GetMessage);
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.ToString());
            }
        }

        public Stream OpenLogStream()
        {
            return null;
        }

        private static string GetMessage(object message, Exception exc)
        {
            if (exc != null)
            {
                message += Environment.NewLine + StringHelper.ExceptionToString(exc);
            }
            return message.ToString();
        }
    }
}