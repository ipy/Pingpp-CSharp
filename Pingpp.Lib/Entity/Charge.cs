using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingpp.Lib.Entity
{
    /// <summary>
    /// Charge 对象
    /// </summary>
    public class Charge
    {
        /// <summary>
        /// 支付对象 id。
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 值为 charge。
        /// </summary>
        public string Object { get; set; }
        /// <summary>
        /// 支付创建的时间，用 UTC 时间表示。
        /// </summary>
        public long Created { get; set; }
        /// <summary>
        /// 支付是否处于 live 模式。
        /// </summary>
        public bool Livemode { get; set; }
        /// <summary>
        /// 是否已付款。
        /// </summary>
        public bool Paid { get; set; }
        /// <summary>
        /// 是否存在退款信息，无论退款是否成功。
        /// </summary>
        public bool Refunded { get; set; }
        /// <summary>
        /// 支付使用的 app 对象的 id。expandable 可展开。
        /// </summary>
        public string App { get; set; }
        /// <summary>
        /// 支付使用的支付渠道：alipay, wx, upmp 对应支付宝，微信，银联。
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// 商户订单号，由 32 位内的字母或数字组成，在商户系统内唯一。
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 发起支付请求终端的 ip 地址，格式为 IPV4 整型，如 127.0.0.1。
        /// </summary>
        public string ClientIp { get; set; }
        /// <summary>
        /// 订单总金额，单位为对应币种的最小货币单位，例如:人民币为分。
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 清算金额，单位为对应币种的最小货币单位，例如人民币为分。
        /// </summary>
        public int AmountSettle { get; set; }
        /// <summary>
        /// 三位 iSO 货币代码，人民币为 cny。
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 商品的标题，该参数最长为 32 个 Unicode 字符。
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 商品的描述信息，该参数最长为 128 个 Unicode 字符。
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 额外的渠道信息。使用某些渠道的时候会有相应的参数，详见 接入指南。
        /// </summary>
        public Extra Extra { get; set; }
        /// <summary>
        /// 订单失效时间，用 UTC 时间表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天，创建时间以 Ping++ 服务器时间为准。该参数不适用于微信支付。
        /// </summary>
        public int TimeExpire { get; set; }
        /// <summary>
        /// 订单清算时间，用 UTC 时间表示。
        /// </summary>
        public int TimeSettle { get; set; }
        /// <summary>
        /// 支付渠道返回的交易流水号。
        /// </summary>
        public string TransactionNo { get; set; }
        /// <summary>
        /// 退款详情列表，详见 refund 退款对象。
        /// </summary>
        public PingppList<Refund> Refunds { get; set; }
        /// <summary>
        /// 已退款总金额，单位为对应币种的最小货币单位，例如人民币为分。
        /// </summary>
        public int AmountRefunded { get; set; }
        /// <summary>
        /// 订单的错误码，详见 Errors 错误处理机制中的错误码描述。
        /// </summary>
        public string FailureCode { get; set; }
        /// <summary>
        /// 订单的错误消息的描述。
        /// </summary>
        public string FailureMsg { get; set; }
        /// <summary>
        /// 参考 Metadata 元数据。
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }
        /// <summary>
        /// 支付凭证，用于客户端发起支付。
        /// </summary>
        public Object Credential { get; set; }
        /// <summary>
        /// 订单附加说明，最多 255 个 Unicode 字符。
        /// </summary>
        public string Description { get; set; }
    }
}
