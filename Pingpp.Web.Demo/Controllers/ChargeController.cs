using Pingpp.Web.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pingpp.Lib;
using System.Configuration;
using Pingpp.Lib.Param;
using Pingpp.Lib.Entity;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Results;

namespace Pingpp.Web.Demo.Controllers
{
    /// <summary>
    /// 客户端发起支付
    /// </summary>
    public class ChargeController : ApiController
    {
        // POST api/charge
        public JsonResult<Charge> Post([FromBody]ChargeModel form)
        {
            var clientIP = HttpContext.Current.Request.UserHostAddress;
            if (clientIP == "::1")
            {
                clientIP = "127.0.0.1";
            }
            var orderID = Guid.NewGuid().ToString().Replace("-", "");
            var pingpp = new Pingpp.Lib.Pingpp(ConfigurationManager.AppSettings["pingpp_key"], ConfigurationManager.AppSettings["pingpp_api_base"]);
            Error error;
            var charge = pingpp.CreateCharge(new ChargeCreateParam()
            {
                OrderNo = orderID,
                App = new Dictionary<string, string>() { { "id", ConfigurationManager.AppSettings["pingpp_appid"] } },
                Amount = form.Amount,
                Channel = form.Channel,
                Currency = "cny",
                ClientIp = clientIP,
                Subject = "Your Subject",
                Body = "Your Body",
                Extra = null
            }, out error);
            if (error == null)
            {
                return Json(charge, new JsonSerializerSettings() {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            }
            else
            {
                return null;
            }
        }
    }
}
