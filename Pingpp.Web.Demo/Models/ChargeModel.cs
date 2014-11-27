using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pingpp.Web.Demo.Models
{
    /// <summary>
    /// 客户端发起支付的参数
    /// </summary>
    public class ChargeModel
    {
        public string Channel { get; set; }
        public int Amount { get; set; }
    }
}