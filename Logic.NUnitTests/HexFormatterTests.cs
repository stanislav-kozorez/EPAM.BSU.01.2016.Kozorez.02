using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using System.Globalization;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class HexFormatterTests
    {
        [TestCase(145, Result = "0X91")]
        [TestCase(-145, Result = "-0X91")]
        [TestCase(0, Result = "0X0")]
        [TestCase(41837, Result = "0XA36D")]
        [TestCase(47, Result = "0X2F")]
        [TestCase(47.2, ExpectedException = typeof(FormatException))]
        public string Format_Test(object number)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IFormatProvider fp = new HexFormatter();

            return string.Format(fp, "{0:H}", number);
        }

        [TestCase(47, "{0:X}", Result = "2F")]
        [TestCase(.473, "{0:P}", Result = "47.30 %")]
        [TestCase(.473, "{0:P0}", Result = "47 %")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.7321, "{0:F2}", Result = "4.73")]
        public string ParentFormat_Test(object number, string format)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IFormatProvider fp = new HexFormatter();

            return string.Format(fp, format, number);
        }
    }
}
