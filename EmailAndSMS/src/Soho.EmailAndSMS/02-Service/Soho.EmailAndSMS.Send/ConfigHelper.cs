using System;
using System.Runtime.Serialization;

namespace Soho.EmailAndSMS.Send
{
    public class ConfigHelper
    {
        #region 配置实例
        private static ConfigHelper _Instance = null;
        public static ConfigHelper Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ConfigHelper();
                return _Instance;
            }
        }
        #endregion

        #region 加载配置
        private EmailAndSMSConfig _Config = null;
        public EmailAndSMSConfig Config
        {
            get
            {
                if (_Config == null)
                { }
                return _Config;
            }
        }
        #endregion
    }

    /// <summary>
    /// 电子邮件和短信配置
    /// </summary>
    [Serializable]
    [DataContract]
    public class EmailAndSMSConfig
    {
        /// <summary>
        /// 电子邮件配置
        /// </summary>
        [DataMember]
        public EmailConfig Email { get; set; }
        /// <summary>
        /// 短信配置
        /// </summary>
        [DataMember]
        public SMSConfig SMS { get; set; }
    }
    /// <summary>
    /// 电子邮件配置
    /// </summary>
    [Serializable]
    [DataContract]
    public class EmailConfig
    {
        /// <summary>
        /// 数据库连接串
        /// </summary>
        [DataMember]
        public string DatabaseConnectionString { get; set; }
        /// <summary>
        /// 发送线程数
        /// </summary>
        [DataMember]
        public int SendThreadCounts { get; set; }
        /// <summary>
        /// 单次加载电子邮件数
        /// </summary>
        [DataMember]
        public int LoadEmailCounts { get; set; }
        /// <summary>
        /// 发送方式实现类
        /// </summary>
        [DataMember]
        public string SendType { get; set; }
    }
    /// <summary>
    /// 短信配置
    /// </summary>
    [Serializable]
    [DataContract]
    public class SMSConfig
    { }
}
