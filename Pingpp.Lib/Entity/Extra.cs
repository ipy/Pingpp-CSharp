using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingpp.Lib.Entity
{
    /// <summary>
    /// optional 某些渠道发起交易时需要的额外参数，详见 接入指南。
    /// </summary>
    public class Extra
    {
        /// <summary>
        /// 仅当 channel 值为 upmp_wap 时支付完成的回调地址。
        /// </summary>
        [Required]
        public string ResultUrl { get; set; }

        /// <summary>
        /// 仅当 channel 值为 alipay_wap 时支付成功的回调地址。
        /// </summary>
        [Required]
        public string SuccessUrl { get; set; }

        /// <summary>
        /// 仅当 channel 值为 alipay_wap 时支付取消的回调地址。
        /// </summary>
        public string CancelUrl { get; set; }
    }
}
