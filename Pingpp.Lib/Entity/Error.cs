using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingpp.Lib.Entity
{
    /// <summary>
    /// Ping++ API 返回的错误信息
    /// </summary>
    public class Error
    {
        /// <summary>
        /// 错误类型，可以是 invalid_request_error、api_error 或 channel_error。
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 返回具体的错误描述。
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 错误码，因为第三方支付渠道返回的错误代码。
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 当发生参数错误时返回具体的参数名，如 id。
        /// </summary>
        public string Param { get; set; }
    }

    public class ErrorWrapper
    {
        public Error Error { get; set; }
    }
}
