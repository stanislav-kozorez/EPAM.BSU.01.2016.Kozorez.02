using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class Task2Tests
    {
        #region GCD tests
        [TestCase(0, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, -4, Result = 4)]
        [TestCase(5, 0, Result = 5)]
        [TestCase(1, 173, Result = 1)]
        [TestCase(466, 1, Result = 1)]
        [TestCase(17, 17, Result = 17)]
        public int GCDTestWith2Params(int firstValue, int secondValue)
        {
            long elapsed;
            int result = Task2.GCD(out elapsed, firstValue, secondValue);
            Debug.WriteLine($"Elapsed time: {elapsed}");

            return result;
        }

        [TestCase(0, 0, 5, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, -4, 10, Result = 2)]
        [TestCase(5, 0, 0, Result = 5)]
        [TestCase(1, 173, 35, Result = 1)]
        [TestCase(466, 1, 22, Result = 1)]
        [TestCase(17, 17, 17, Result = 17)]
        [TestCase(17453, 123567, 13477, Result = 1)]
        public int GCDTestWith3Params(int firstValue, int secondValue, int thirdValue)
        {
            long elapsed;
            int result = Task2.GCD(out elapsed, firstValue, secondValue, thirdValue);
            Debug.WriteLine($"Elapsed time: {elapsed}");

            return result;
        }

        [TestCase(4, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, 0, 5, 10, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, -4, 10, 2, Result = 2)]
        [TestCase(5, 0, 0, 0, Result = 5)]
        [TestCase(1, 173, 35, 44, Result = 1)]
        [TestCase(466, 1, 22, 14, Result = 1)]
        [TestCase(17, 17, 17, 17, Result = 17)]
        public int GCDTestWithParams(params int[] values)
        {
            long elapsed;
            int result = Task2.GCD(out elapsed, values);
            Debug.WriteLine($"Elapsed time: {elapsed}");

            return result;
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void GCDTestWithNullParams()
        {
            long elapsed;
            int[] args = null;
            int result = Task2.GCD(out elapsed, args);
            Debug.WriteLine($"Elapsed time: {elapsed}");
        }

        #endregion

        #region Binary GCD tests

        [TestCase(0, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, -4, Result = 4)]
        [TestCase(5, 0, Result = 5)]
        [TestCase(1, 173, Result = 1)]
        [TestCase(466, 1, Result = 1)]
        [TestCase(17, 17, Result = 17)]
        public int BinaryGCDTestWith2Params(int firstValue, int secondValue)
        {
            long elapsed;
            int result = Task2.BinaryGCD(out elapsed, firstValue, secondValue);
            Debug.WriteLine($"Elapsed time: {elapsed}");

            return result;
        }

        [TestCase(0, 0, 5, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, -4, 10, Result = 2)]
        [TestCase(5, 0, 0, Result = 5)]
        [TestCase(1, 173, 35, Result = 1)]
        [TestCase(466, 1, 22, Result = 1)]
        [TestCase(17, 17, 17, Result = 17)]
        [TestCase(17453, 123567, 13477, Result = 1)]
        public int BinaryGCDTestWith3Params(int firstValue, int secondValue, int thirdValue)
        {
            long elapsed;
            int result = Task2.BinaryGCD(out elapsed, firstValue, secondValue, thirdValue);
            Debug.WriteLine($"Elapsed time: {elapsed}");

            return result;
        }

        [TestCase(4, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, 0, 5, 10, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, -4, 10, 2, Result = 2)]
        [TestCase(5, 0, 0, 0, Result = 5)]
        [TestCase(1, 173, 35, 44, Result = 1)]
        [TestCase(466, 1, 22, 14, Result = 1)]
        [TestCase(17, 17, 17, 17, Result = 17)]
        public int BinaryGCDTestWithParams(params int[] values)
        {
            long elapsed;
            int result = Task2.BinaryGCD(out elapsed, values);
            Debug.WriteLine($"Elapsed time: {elapsed}");

            return result;
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void BinaryGCDTestWithNullParams()
        {
            long elapsed;
            int[] args = null;
            int result = Task2.BinaryGCD(out elapsed, args);
            Debug.WriteLine($"Elapsed time: {elapsed}");
        }

        #endregion
    }
}
