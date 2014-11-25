using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingpp.Lib.Utils
{
    public static class StringExtension
    {
        /// <summary>
        /// 把 CamelCase 的字符串转换为 snake_case
        /// </summary>
        /// <param name="camel"></param>
        /// <returns></returns>
        public static string ToSnakeCase(this string camel)
        {
            return string.IsNullOrEmpty(camel) ? camel : string.Concat(
                camel.Select((x, i) =>
                    char.IsUpper(x) ? "_" + x.ToString().ToLower() : x.ToString()
                )
            ).TrimStart('_');
        }
    }
}
