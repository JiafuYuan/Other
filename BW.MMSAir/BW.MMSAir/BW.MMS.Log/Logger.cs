using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;

namespace BW.MMS.Log
{
    public sealed class Logger
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Debug(object s)
        {
            if (logger.IsDebugEnabled)
                logger.Debug(s);
        }

        public static void Info(object s)
        {
            if (logger.IsInfoEnabled)
                logger.Info(s);
        }

        public static void Warn(object s)
        {
            if (logger.IsWarnEnabled)
                logger.Warn(s);
        }

        public static void Error(object s)
        {
            if (logger.IsErrorEnabled)
                logger.Error(s);
        }

        public static void Error(object s, Exception e)
        {
            if (logger.IsErrorEnabled)
                logger.Error(s, e);
        }

        public static void Fatal(object s)
        {
            if (logger.IsFatalEnabled)
                logger.Fatal(s);
        }

        public static void Fatal(object s, Exception e)
        {
            if (logger.IsFatalEnabled)
                logger.Fatal(s, e);
        }

    }
}
