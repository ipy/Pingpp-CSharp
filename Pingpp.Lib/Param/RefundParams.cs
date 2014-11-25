using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingpp.Lib.Param
{
    /// <summary>
    /// 创建 Refund 对象的参数
    /// </summary>
    public class RefundCreateParam : BaseParam
    {
        /// <summary>
        /// charge 对象的 id。
        /// </summary>
        [Required]
        public string Id { get; set; }
        /// <summary>
        /// 退款的金额, 单位为对应币种的最小货币单位，例如人民币为分。必须小于等于可退款金额，默认为全额退款。
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 退款详情，最多 255 个 Unicode 字符。
        /// </summary>
        [Required]
        public string Description { get; set; }
    }

    /// <summary>
    /// 查询单条 Refund 记录的参数
    /// </summary>
    public class RefundRetrieveParam : BaseParam
    {
        /// <summary>
        /// 查询的 refund 对象 id。
        /// </summary>
        [Required]
        public string Id { get; set; }
        /// <summary>
        /// 退款的 charge 对象 id。
        /// </summary>
        [Required]
        public string Charge { get; set; }
    }

    /// <summary>
    /// 查询 Refund 列表的参数
    /// </summary>
    public class RefundListParam : BaseParam
    {
        /// <summary>
        /// 指定退款所在 charge 对象的 id。
        /// </summary>
        public string Id { get; set; }

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
    }
}
