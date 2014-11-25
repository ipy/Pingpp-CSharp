using System;
using System.Collections.Generic;
using Pingpp.Lib.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Pingpp.Lib.Test
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void SnakeCaseTeset()
        {
            Assert.AreEqual("CamelCase".ToSnakeCase(), "camel_case");
            string strNull = null;
            Assert.AreEqual(strNull.ToSnakeCase(), null);
        }
    }
}
