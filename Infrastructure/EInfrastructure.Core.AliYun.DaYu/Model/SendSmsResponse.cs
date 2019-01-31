﻿using System.Xml.Serialization;

namespace EInfrastructure.Core.AliYun.DaYu.Model
{
    /// <summary>
    /// 发送短信响应信息
    /// </summary>
    [XmlRoot]
    internal class SendSmsResponse
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement]
        public string Message { get; set; }

        /// <summary>
        /// 请求id
        /// </summary>
        [XmlElement]
        public string RequestId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement]
        public string BizId { get; set; }

        /// <summary>
        /// 响应Code
        /// </summary>
        [XmlElement]
        public string Code { get; set; }
    }
}
