using System;
using System.Collections.Generic;
using Pingpp.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using Pingpp.Lib.Entity;
using Pingpp.Lib.Param;

namespace Pingpp.Lib.Test
{
    [TestClass]
    public class ChargeTest
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
        public void CreateChargeTest()
        {
            var pingpp = new Pingpp(KEY);
            Error error;
            var charge = pingpp.CreateCharge(new ChargeCreateParam()
            {
                OrderNo = Guid.NewGuid().ToString().Replace("-",""),
                App = new Dictionary<string, string>() { { "id", APPID } },
                Channel = "alipay",
                Amount = 10000000,
                ClientIp = "127.0.0.1",
                Currency = "cny",
                Subject = "测试 " + DateTime.Now.ToString(),
                Body = "测试",
                Metadata = new Dictionary<string, string>() { { "test", "test metadata" } },
            }, out error);
            Assert.IsNotNull(charge);
            Assert.IsNull(error);
        }

        [TestMethod]
        public void ListChargeTest()
        {
            var pingpp = new Pingpp(KEY);
            Error error;
            var charges = pingpp.ListCharge(new ChargeListParam(), out error);
            Assert.IsNotNull(charges);
            Assert.IsNull(error);
        }
        
        [TestMethod]
        public void RetrieveChargeTest()
        {
            var pingpp = new Pingpp(KEY);
            Error error;
            var charge = pingpp.RetrieveCharge(new ChargeRetrieveParam()
            {
                Id = "ch_Hy1i189SG408HiHmb1L4qXH4"
            }, out error);
            Assert.IsNotNull(charge);
            Assert.IsNull(error);
        }
    }
}
