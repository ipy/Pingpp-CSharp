using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pingpp.Lib.Request
{
    public class Request
    {
        private string baseUrl;
        KeyValuePair<string, string> credential;
        public Request(string baseUrl, KeyValuePair<string, string> credential)
        {
            this.baseUrl = baseUrl;
            this.credential = credential;
        }

        public HttpWebRequest CreateRequest(string path, string method
            , Dictionary<string, string> param)
        {
            var paramInUrl = new List<string>();
            foreach (KeyValuePair<string, string> pair in param)
            {
                var placeholder = "{" + pair.Key + "}";
                if (path.IndexOf(placeholder) >= 0)
                {
                    path = path.Replace(placeholder, pair.Value);
                    paramInUrl.Add(pair.Key);
                }
            }
            foreach (var name in paramInUrl)
            {
                param.Remove(name);
            }
            var url = this.baseUrl + path;
            var dataStr = param.Aggregate(string.Empty, (acc, pair) =>
                (acc + Uri.EscapeDataString(pair.Key)
                    + "="
                    + Uri.EscapeDataString(pair.Value)
                    + "&"),
                res => res.ToString().TrimEnd('&'));
            HttpWebResponse response;
            if (method == "GET")
            {
                url = string.IsNullOrEmpty(dataStr) ? url : (url + "?" + dataStr);
            }
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = new NetworkCredential(this.credential.Key, this.credential.Value);
            request.Method = method;
            if (method == "POST")
            {
                request.ContentType = "application/x-www-form-urlencoded";
                var data = Encoding.ASCII.GetBytes(dataStr);
                request.ContentLength = data.Length;
                using (var reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }
            }
            return request;
        }
    }
}
