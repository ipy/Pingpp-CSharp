using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingpp.Lib.Entity
{
    /// <summary>
    /// Refund 对象
    /// </summary>
    public class Refund
    {
        /// <summary>
        /// refund 对象 id。
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 值为 refund。
        /// </summary>
        public string Object { get; set; }
        /// <summary>
        /// 退款的订单号，由 Ping++ 生成。
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 退款金额，单位为对应币种的最小货币单位，人民币为分。
        /// </summary>
        public int Amount {get; set;}
        /// <summary>
        /// 退款是否成功。
        /// </summary>
        public bool Succeed { get; set; }
        /// <summary>
        /// 退款创建的时间，用 UTC 时间表示。
        /// </summary>
        public int Created { get; set; }
        /// <summary>
        /// 退款成功的时间，用 UTC 时间表示。
        /// </summary>
        public int TimeSucceed { get; set; }
        /// <summary>
        /// 退款详情，最多 255 个 Unicode 字符。
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 退款的错误码，详见 Errors 错误处理机制中的错误码。
        /// </summary>
        public string FailureCode { get; set; }
        /// <summary>
        /// 退款消息的描述。
        /// </summary>
        public string FailureMsg { get; set; }
        /// <summary>
        /// 参考 Metadata 元数据。
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }
        /// <summary>
        /// refund 对象的所在 charge 对象的 id。
        /// </summary>
        public string Charge { get; set; }
    }
}
