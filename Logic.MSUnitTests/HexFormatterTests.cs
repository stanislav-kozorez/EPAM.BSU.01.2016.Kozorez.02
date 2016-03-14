using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.MSUnitTests
{
    [TestClass]
    public class HexFormatterTests
    {
        [TestMethod]
        public void Format_SByteValueAndUppercaseFormat_ReturnedUppercaseHexString()
        {
            sbyte initial = 27;
            string expected = "0X1B";

            string actual = String.Format(new HexFormatter(), "{0:H}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_SByteValueAndLowercaseFormat_ReturnedLowercaseHexString()
        {
            sbyte initial = -27;
            string expected = "-0x1b";

            string actual = String.Format(new HexFormatter(), "{0:h}", initial);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Format_ByteValueAndUppercaseFormat_ReturnedUppercaseHexString()
        {
            byte initial = 95;
            string expected = "0X5F";

            string actual = String.Format(new HexFormatter(), "{0:H}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_ByteValueAndLowercaseFormat_ReturnedLowercaseHexString()
        {
            byte initial = 95;
            string expected = "0x5f";

            string actual = String.Format(new HexFormatter(), "{0:h}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_UShortValueAndUppercaseFormat_ReturnedUppercaseHexString()
        {
            ushort initial = 512;
            string expected = "0X200";

            string actual = String.Format(new HexFormatter(), "{0:H}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_UShortValueAndLowercaseFormat_ReturnedLowercaseHexString()
        {
            ushort initial = 512;
            string expected = "0x200";

            string actual = String.Format(new HexFormatter(), "{0:h}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_shortValueAndUppercaseFormat_ReturnedUppercaseHexString()
        {
            short initial = -754;
            string expected = "-0X2F2";

            string actual = String.Format(new HexFormatter(), "{0:H}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_shortValueAndLowercaseFormat_ReturnedLowercaseHexString()
        {
            short initial = 754;
            string expected = "0x2f2";

            string actual = String.Format(new HexFormatter(), "{0:h}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_UintValueAndUppercaseFormat_ReturnedUppercaseHexString()
        {
            uint initial = 1564;
            string expected = "0X61C";

            string actual = String.Format(new HexFormatter(), "{0:H}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_UIntValueAndLowercaseFormat_ReturnedLowercaseHexString()
        {
            uint initial = 1564;
            string expected = "0x61c";

            string actual = String.Format(new HexFormatter(), "{0:h}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_IntValueAndUppercaseFormat_ReturnedUppercaseHexString()
        {
            int initial = -1195;
            string expected = "-0X4AB";

            string actual = String.Format(new HexFormatter(), "{0:H}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_IntValueAndLowercaseFormat_ReturnedLowercaseHexString()
        {
            int initial = 1195;
            string expected = "0x4ab";

            string actual = String.Format(new HexFormatter(), "{0:h}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_LongValueAndUppercaseFormat_ReturnedUppercaseHexString()
        {
            long initial = -11165495;
            string expected = "-0XAA5F37";

            string actual = String.Format(new HexFormatter(), "{0:H}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_LongValueAndLowercaseFormat_ReturnedLowercaseHexString()
        {
            long initial = 11165495;
            string expected = "0xaa5f37";

            string actual = String.Format(new HexFormatter(), "{0:h}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_ULongValueAndUppercaseFormat_ReturnedUppercaseHexString()
        {
            ulong initial = 4687945883;
            string expected = "0X1176C609B";

            string actual = String.Format(new HexFormatter(), "{0:H}", initial);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Format_ULongValueAndLowercaseFormat_ReturnedLowercaseHexString()
        {
            ulong initial = 4687945883;
            string expected = "0x1176c609b";

            string actual = String.Format(new HexFormatter(), "{0:h}", initial);
            Assert.AreEqual(expected, actual);
        }
    }
}
