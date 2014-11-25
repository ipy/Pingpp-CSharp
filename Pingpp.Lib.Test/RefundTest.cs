using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pingpp.Lib;
using Pingpp.Lib.Entity;
using Pingpp.Lib.Param;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingpp.Lib.Test
{
    [TestClass]
    public class RefundTest
    {
        public string KEY
        {
            get
            {
                return ConfigurationManager.AppSettings["pingpp_key"];
            }
        }
        public string APPID
        {
            get
            {
                return ConfigurationManager.AppSettings["pingpp_appid"];
            }
        }


        [TestMethod]
        public void CreateRefundTest()
        {
            var pingpp = new Pingpp(KEY);
            Error error;
            var refund = pingpp.CreateRefund(new RefundCreateParam()
            {
                Id = "ch_O888e1ynnTS4anPejL8KurDC",
                Amount = 2,
                Description = "没啥可说的",
            }, out error);
            Assert.IsNotNull(refund);
            Assert.IsNull(error);
        }

        [TestMethod]
        public void ListRefundTest()
        {
            var pingpp = new Pingpp(KEY);
            Error error;
            var refunds = pingpp.ListRefund(new RefundListParam()
            {
                Id = "ch_O888e1ynnTS4anPejL8KurDC",
            }, out error);
            Assert.IsNotNull(refunds);
            Assert.IsNull(error);
        }

        [TestMethod]
        public void RetrieveRefundTest()
        {
            var pingpp = new Pingpp(KEY);
            Error error;
            var refund = pingpp.RetrieveRefund(new RefundRetrieveParam()
            {
                Id = "ch_O888e1ynnTS4anPejL8KurDC",
            }, out error);
            Assert.IsNotNull(refund);
            Assert.IsNull(error);
        }
    }
}
