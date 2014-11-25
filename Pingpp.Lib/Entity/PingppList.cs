using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingpp.Lib.Entity
{
    /// <summary>
    /// Charge 对象列表
    /// </summary>
    public class PingppList<T>
    {
        #region 快捷方式
        public T this[int i] { get { return Data[i]; } }
        public int Count { get { return Data.Count; } }
        #endregion

        #region 字段
        public List<T> Data { get; set; }
        public string Object { get; set; }
        public string Url { get; set; }
        public bool HasMore { get; set; }
        #endregion
    }
}
