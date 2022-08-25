using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace LogManager
{
    public interface ILogMan
    {
        void CreateLog( bool deleteOldLogFiles,
                        Int16 oldFilesDuration,
                        string logFolder,
                        string fileNamePrefix );

        void Log( LogLevel level,
                  string source,
                  string message,
                  DateTime timestamp,
                  Boolean MessageFormated);

        void Log( string message );
    }


    public enum LogLevel { Fatal, Exception, Error, Debug, Information, Unknown };


    public class LogMan : ILogMan
    {
        static private Object logLock = new Object();
        static private LogMan _Instance = new LogMan();

        static public LogMan Instance
        {
            get
            {
                return _Instance;
            }
            set
            {
                _Instance = null;
            }
        }
        private int m_oldFilesDuration = 100;
        public int oldFilesDuration
        {
            get { return m_oldFilesDuration; }
            set { m_oldFilesDuration = value; }
        }
       
        private bool m_deleteOldLogFiles = true;
        public bool deleteOldLogFiles 
        {
            get { return m_deleteOldLogFiles; }
            set { m_deleteOldLogFiles = value; }
        }

        private string m_logFilesFolder = "C:/Temp/LogFiles";
        public string logFileFoldes
        {
            get { return m_logFilesFolder; }
            set { m_logFilesFolder = value; }
        }

        private string m_fileNamePrefix = "fileNamePrefix";
        public string fileNamePreFix
        {
            get { return m_fileNamePrefix; }
            set { m_fileNamePrefix = value; }
        }

        public void Log( LogLevel level,
                         string source,
                         string message,
                         DateTime timestamp,
                         Boolean formatMessage)
        {
            lock (logLock)
            {
                AddLogToFile(level, source, message, timestamp, formatMessage);
            }
        }


        public void Log( string message )
        {
            lock (logLock)
            {
                AddLogToFile(LogLevel.Unknown, "", message, DateTime.Now, false);
            }
        }

        public void CreateLog( bool deleteOldLogFiles,
                               Int16 oldFilesDuration,
                               string logFolder,
                               string filePreFix)
        {
            try
            {
                m_deleteOldLogFiles = deleteOldLogFiles;
                m_oldFilesDuration  = oldFilesDuration;
                m_logFilesFolder    = logFolder;
                m_fileNamePrefix    = filePreFix;

                /* Create Log File Folder if not already exist */
                if (!Directory.Exists(m_logFilesFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(m_logFilesFolder);
                }
            }

            catch { }
        }

        private void AddLogToFile( LogLevel level,
                                 string source,
                                 string message,
                                 DateTime timestamp,
                                 Boolean formatMessage)
        {
            DeleteOldLogFile();

            string FileName = Path.Combine( m_logFilesFolder,
                                            m_fileNamePrefix +
                                            string.Format("{0}.log", DateTime.Today.ToString("yyyyMMdd")));

            TextWriter LogFil = null;

            try
            {
                string Message;

                if (formatMessage)
                {
                    Message = string.Format("{0:yyyy-MM-dd} {0:HH:mm:ss} {1}. {2} Source: {3}.",
                                            timestamp, level.ToString(), message, source);
                }
                else
                {
                    //Message = string.Format( "{0:yyyy-MM-dd} {0:HH:mm:ss} {1}", DateTime.Now, message );
                    Message = string.Format( "{0:HH:mm:ss} {1}", timestamp, message );
                }
                LogFil = File.AppendText(FileName);
                LogFil.WriteLine(Message);
                LogFil.Flush();
            }

            catch (Exception e)
            {
                string str = e.Message;
            }

            finally
            {
                if (LogFil != null)
                {
                    LogFil.Close();
                }
            }
        }

        private Decimal GetFileSize(long Bytes)

        { 
            if (Bytes >= 1048576)
            { 
                Decimal size = Decimal.Divide(Bytes, 1048576);
                return size;
            }

            return new Decimal(0) ;
        }

        private void DeleteOldLogFile()
        {
            try
            {
                if (m_deleteOldLogFiles)
                {
                    int i = Convert.ToInt16(m_oldFilesDuration);
                    string OldFileName = Path.Combine(m_logFilesFolder,
                                                      m_fileNamePrefix +
                                                      string.Format("{0}.log", DateTime.Today.AddDays(-i).ToString("yyyyMMdd")));

                    File.Delete(OldFileName);
                }
            }

            catch
            { }
        }
    }
}
