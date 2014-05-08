using System;
using System.IO;
using System.Text;

namespace Soho.EmailAndSMS.Service
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// 写业务日志
        /// </summary>
        /// <param name="contents"></param>
        public static void WriteBizLogs(string contents)
        {
            DateTime dtNow = DateTime.Now;
            string filePath = string.Format("Log/BizLog/{0}/{1}/{2}.txt", dtNow.Year, dtNow.Month, dtNow.ToString("yyyy-MM-dd"));
            filePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, filePath);
            WriteLog(filePath, contents);
        }
        /// <summary>
        /// 写异常日志
        /// </summary>
        /// <param name="contents"></param>
        public static void WriteException(string contents)
        {
            DateTime dtNow = DateTime.Now;
            string filePath = string.Format("Log/ExceptionLog/{0}/{1}/{2}.txt", dtNow.Year, dtNow.Month, dtNow.ToString("yyyy-MM-dd"));
            filePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, filePath);
            WriteLog(filePath, contents);
        }
        /// <summary>
        /// 写日志文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="contents">日志内容</param>
        public static void WriteLog(string filePath, string contents)
        {
            string fileDirection = filePath.Substring(0, filePath.LastIndexOf('/') + 1);
            if (!Directory.Exists(fileDirection))
            {
                Directory.CreateDirectory(fileDirection);
            }
            DateTime now = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n** [" + now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] - Begin **************************************************************\r\n");
            sb.Append(contents);
            sb.Append("\r\n** [" + now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] - End ****************************************************************\r\n");
            byte[] textByte = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            lock (filePath)
            {
                using (FileStream logStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Write))
                {
                    logStream.Write(textByte, 0, textByte.Length);
                    logStream.Close();
                }
            }
        }
    }
}
