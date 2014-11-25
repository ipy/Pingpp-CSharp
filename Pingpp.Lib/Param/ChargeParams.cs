using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingpp.Lib.Param
{
    /// <summary>
    /// 创建 Charge 对象的参数
    /// </summary>
    public class ChargeCreateParam : BaseParam
    {
        /// <summary>
        /// 商户订单号，由 8-32 位内的字母或数字组成，必须在商户系统内唯一。
        /// </summary>
        [Required]
        public string OrderNo { get; set; }
        /// <summary>
        /// 支付使用的 app 对象的 id。
        /// </summary>
        /// todo
        [Required]
        public Dictionary<string, string> App { get; set; }
        /// <summary>
        /// 支付使用的支付渠道：alipay, wx, upmp 对应支付宝，微信，银联。
        /// </summary>
        [Required]
        public string Channel { get; set; }
        /// <summary>
        /// 订单总金额, 单位为对应币种的最小货币单位，例如:人民币为分。
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
        /// <summary>
        /// 发起支付请求终端的 IP 地址，格式为 IPV4，如: 127.0.0.1。
        /// </summary>
        [Required]
        public string ClientIp { get; set; }
        /// <summary>
        /// 三位 iSO 货币代码，目前仅支持人民币 cny。
        /// </summary>
        [Required]
        public string Currency { get; set; }
        /// <summary>
        /// 商品的标题，该参数最长为 32 个 Unicode 字符。
        /// </summary>
        [Required]
        public string Subject { get; set; }
        /// <summary>
        /// 商品的描述信息，该参数最长为 128 个 Unicode 字符。
        /// </summary>
        [Required]
        public string Body { get; set; }
        /// <summary>
        /// optional 某些渠道发起交易时需要的额外参数，详见 接入指南。
        /// </summary>

        public string Extra { get; set; }
        /// <summary>
        /// 订单失效时间，用 UTC 时间表示。时间范围在订单创建后的 1 分钟到 15 天，默认为 1 天，创建时间以 Ping++ 服务器时间为准。该参数不适用于微信支付渠道。
        /// </summary>

        public string TimeExpire { get; set; }
        /// <summary>
        /// 参考 Metadata 元数据。
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }
        /// <summary>
        /// 订单附加说明，最多 255 个 Unicode 字符。
        /// </summary>

        public string Description { get; set; }
    }

    /// <summary>
    /// 获取单个 Charge 对象的参数
    /// </summary>
    public class ChargeRetrieveParam : BaseParam
    {
        [Required]
        public string Id { get; set; }
    }

    /// <summary>
    /// 获取 Charge 对象列表的参数
    /// </summary>
    public class ChargeListParam : BaseParam
    {
        /// <summary>
        /// 限制每页可以返回多少对象，范围为 1-100 项，默认是 10 项。
        /// </summary>
        public string Limit { get; set; }

        /// <summary>
        /// 在分页时使用的指针，决定了列表的第一项从何处开始。假设你的一次请求返回列表的最后一项的 id 是 obj_end，你可以使用 starting_after = obj_end 去获取下一页。
        /// </summary>
        public string StartingAfter { get; set; }

        /// <summary>
        /// 在分页时使用的指针，决定了列表的最末项在何处结束。假设你的一次请求返回列表的最后一项的 id 是 obj_start，你可以使用 ending_before = obj_start 去获取上一页。
        /// </summary>
        public string EndingBefore { get; set; }

        /// <summary>
        /// 对象的创建时间，用 UTC 时间表示。
        /// created[gt]: 大于 charge 对象的创建时间，用 UTC 时间表示。
        /// created[gte]: 大于或等于 charge 对象的创建时间，用 UTC 时间表示。
        /// created[lt]: 小于 charge 对象的创建时间，用 UTC 时间表示。
        /// created[lte]: 小于或等于 charge 对象的创建时间，用 UTC 时间表示。
        /// </summary>
        public Dictionary<string, string> Created { get; set; }

        /// <summary>
        /// 支付使用的 app 对象的 id。
        /// </summary>
        public Dictionary<string, string> App { get; set; }

        /// <summary>
        /// 支付使用的支付渠道：alipay、wx、upmp， 对应支付宝、微信、银联。
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 是否已付款。
        /// </summary>
        public string Paid { get; set; }

        /// <summary>
        /// 是否存在退款信息，无论退款是否成功。
        /// </summary>
        public string Refunded { get; set; }
    }
}
