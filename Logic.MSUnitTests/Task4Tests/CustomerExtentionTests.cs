using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Globalization;

namespace Logic.MSUnitTests
{
    [TestClass]
    public class CustomerExtentionTests
    {
        [TestMethod]
        public void ToStringExt_WithGParamsAndNullProvider_ReturnedGeneralFormat()
        {
            string expected = "Name: Mike\nTelephone: 375348572354\nRevenue: 10000";
            Cusomer c = new Cusomer("Mike", 375348572354, 10000);
            string actual = c.ToStringExt("g", null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringExt_WithNTRFormatStringAndFormatProvider_ReturnedFormattedString()
        {
            string expected = "Name: MikeName: Mike[+375 348 572 354]$10,000.00";
            Cusomer c = new Cusomer("Mike", 375348572354, 10000);
            string actual = c.ToStringExt("NNTR", new CultureInfo("en-US"));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringExt_WithXFormatStringAndNullFormatProvider_ReturnedXMlString()
        {
            string expected = "<customer>\n\t<name>Mike</name>\n\t<telephone>+(375) 348-572-354</telephone>\n\t<revenue>$10,000.00</revenue>\n</customer>";
            Cusomer c = new Cusomer("Mike", 375348572354, 10000);
            string actual = c.ToStringExt("X", new CultureInfo("en-US"));

            Assert.AreEqual(expected, actual);
        }
    }
}
