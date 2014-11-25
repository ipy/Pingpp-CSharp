using Pingpp.Lib.Entity;
using Pingpp.Lib.Param;
using Pingpp.Lib.Request;
using Pingpp.Lib.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pingpp.Lib
{
    public class Pingpp
    {
        private string baseUrl, key;
        public Pingpp(string key, string baseUrl = "https://api.pingplusplus.com/v1/")
        {
            this.key = key;
            this.baseUrl = baseUrl;
        }

        /// <summary>
        /// 发起 API 请求并处理返回结果
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <typeparam name="U">参数类型</typeparam>
        /// <param name="api">Ping++ API 接口</param>
        /// <param name="method">HTTP 方法</param>
        /// <param name="param">参数</param>
        /// <param name="error">Ping++ 返回的错误</param>
        /// <returns></returns>
        private T GetResponse<T, U>(string api, string method, U param, out Error error)
            where T : class
            where U : BaseParam
        {
            var requester = new Request.Request(this.baseUrl, new KeyValuePair<string, string>(this.key, ""));
            var request = requester.CreateRequest(api, method, param.ToDictionary());
            HttpWebResponse response;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
                error = null;
                var stream = (Stream)response.GetResponseStream();
                return stream.DeserializeToJson<T>();
            }
            catch (System.Net.WebException ex)
            {
                response = ex.Response as HttpWebResponse;
                if (response != null)
                {
                    var statusCode = (int)response.StatusCode;
                    if (statusCode >= 400 && statusCode < 500)
                    {
                        var stream = (Stream)response.GetResponseStream();
                        error = stream.DeserializeToJson<ErrorWrapper>().Error;
                        return null;
                    }
                }
                throw;
            }
        }

        /// <summary>
        /// 创建 Charge 对象
        /// </summary>
        /// <param name="param">参数</param>
        /// <param name="error">Ping++ 返回的错误</param>
        /// <returns></returns>
        public Charge CreateCharge(ChargeCreateParam param, out Error error)
        {
            return GetResponse<Charge, ChargeCreateParam>("charges", "POST", param, out error);
        }

        /// <summary>
        /// 查询单个 Charge 对象
        /// </summary>
        /// <param name="param">参数</param>
        /// <param name="error">Ping++ 返回的错误</param>
        /// <returns></returns>
        public Charge RetrieveCharge(ChargeRetrieveParam param, out Error error)
        {
            return GetResponse<Charge, ChargeRetrieveParam>("charges/{id}", "GET", param, out error);
        }

        /// <summary>
        /// 查询 Charge 对象列表
        /// </summary>
        /// <param name="param">参数</param>
        /// <param name="error">Ping++ 返回的错误</param>
        /// <returns></returns>
        public PingppList<Charge> ListCharge(ChargeListParam param, out Error error)
        {
            return GetResponse<PingppList<Charge>, ChargeListParam>("charges", "GET", param, out error);
        }

        /// <summary>
        /// 创建 Refund 对象
        /// </summary>
        /// <param name="param">参数</param>
        /// <param name="error">Ping++ 返回的错误</param>
        /// <returns></returns>
        public Refund CreateRefund(RefundCreateParam param, out Error error)
        {
            return GetResponse<Refund, RefundCreateParam>("charges/{id}/refunds", "POST", param, out error);
        }

        /// <summary>
        /// 查询单条 Refund 对象
        /// </summary>
        /// <param name="param">参数</param>
        /// <param name="error">Ping++ 返回的错误</param>
        /// <returns></returns>
        public Refund RetrieveRefund(RefundRetrieveParam param, out Error error)
        {
            return GetResponse<Refund, RefundRetrieveParam>("charges/{charge}/refunds/{id}", "GET", param, out error);
        }

        /// <summary>
        /// 查询 Refund 对象列表
        /// </summary>
        /// <param name="param">参数</param>
        /// <param name="error">Ping++ 返回的错误</param>
        /// <returns></returns>
        public PingppList<Refund> ListRefund(RefundListParam param, out Error error)
        {
            return GetResponse<PingppList<Refund>, RefundListParam>("charges/{id}/refunds", "GET", param, out error);
        }
    }
}
