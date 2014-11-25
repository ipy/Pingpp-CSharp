using System;
using System.Collections.Generic;
using Pingpp.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using Pingpp.Lib.Param;

namespace Pingpp.Lib.Test
{
    class TestParam : BaseParam
    {
        public string StrArg { get; set; }
        [Required]
        public string RequiredArg { get; set; }
        public Dictionary<string, string> DictArg { get; set; }
    }

    [TestClass]
    public class ParamTest
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ParamToDictionaryTest()
        {
            var param = new TestParam()
            {
                StrArg = "test",
                RequiredArg = "test2",
                DictArg = new Dictionary<string, string>() { { "key", "value" } }
            };
            var dict = param.ToDictionary();
            Assert.IsTrue(dict.ContainsKey("str_arg"));
            Assert.AreEqual(dict["str_arg"], "test");
            Assert.IsTrue(dict.ContainsKey("dict_arg[key]"));
            Assert.AreEqual(dict["dict_arg[key]"], "value");
            param.RequiredArg = null;
            param.ToDictionary();
        }

    }
}
