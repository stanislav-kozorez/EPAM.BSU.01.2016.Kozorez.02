using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Globalization;

namespace Logic.MSUnitTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void ToString_WithoutParams_ReturnedGeneralFormat()
        {
            string expected = "Name: Mike\nTelephone: 375348572354\nRevenue: 10000";
            Cusomer c = new Cusomer("Mike", 375348572354, 10000);
            string actual = c.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_WithFormatString_ReturnedFormattedString()
        {
            string expected = "MikeMike+(375) 348-572-35410 000,00 р.";
            Cusomer c = new Cusomer("Mike", 375348572354, 10000);
            string actual = c.ToString("NNTR");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_WithFormatStringAndFormatProvider_ReturnedFormattedString()
        {
            string expected = "Mike\n+(375) 348-572-354\n$10,000.00";
            Cusomer c = new Cusomer("Mike", 375348572354, 10000);
            string actual =  String.Format(new CultureInfo("en-US"),"{0:N}\n{0:T}\n{0:R}", c);

            Assert.AreEqual(expected, actual);
        }
    }
}
