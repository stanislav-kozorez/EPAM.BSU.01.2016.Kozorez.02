using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class Task2
    {
        private static Stopwatch timer = new Stopwatch();
        private delegate int EuclidMethodChoiceDel(int a, int b); 
        private static Dictionary<string, EuclidMethodChoiceDel> EuclidianMethods;

        static Task2()
        {
            EuclidianMethods = new Dictionary<string, EuclidMethodChoiceDel>()
            {
                {"Not binary",  GCDImplementation},
                {"Binary", BinaryGCDImplementation}
            };
        }

        public static int GCD(out long elapsedMilliseconds, int firstValue, int secondValue)
        {
            return EuclidianCallWith2Params(out elapsedMilliseconds, "Not binary", firstValue, secondValue);
        }

        public static int GCD(out long elapsedMilliseconds, int firstValue, int secondValue, int thirdValue)
        {
            return EuclidianCallWith3Params(out elapsedMilliseconds, "Not binary", firstValue, secondValue, thirdValue);
        }

        public static int GCD(out long elapsedMilliseconds, params int[] values)
        {
            return EuclidianCallWithParams(out elapsedMilliseconds, "Not binary", values);
        }

        private static int GCDImplementation(int firstValue, int secondValue)
        {
            if (firstValue == 0 && secondValue == 0)
                throw new ArgumentException("Unable to find the GCD of zero values");
            if (firstValue == 0)
                return secondValue;
            if (secondValue == 0)
                return firstValue;
            if (firstValue == secondValue)
                return firstValue;
            if (firstValue == 1 || secondValue == 1)
                return 1;

            while (firstValue != secondValue)
            {
                if (firstValue > secondValue)
                    firstValue = firstValue - secondValue;
                else
                    secondValue = secondValue - firstValue;
            }
            return firstValue;
        }

        public static int BinaryGCD(out long elapsedMilliseconds, int firstValue, int secondValue)
        {
            return EuclidianCallWith2Params(out elapsedMilliseconds, "Binary", firstValue, secondValue);
        }

        public static int BinaryGCD(out long elapsedMilliseconds, int firstValue, int secondValue, int thirdValue)
        {
            return EuclidianCallWith3Params(out elapsedMilliseconds, "Binary", firstValue, secondValue, thirdValue);            
        }

        public static int BinaryGCD(out long elapsedMilliseconds, params int[] values)
        {
            return EuclidianCallWithParams(out elapsedMilliseconds, "Binary", values);            
        }

        private static int BinaryGCDImplementation(int firstValue, int secondValue)
        {
            int result = 0;

            if (firstValue == 0 && secondValue == 0)
                throw new ArgumentException("Unable to find the GCD of zero values");
            if (firstValue == 0)
                return secondValue;
            if (secondValue == 0)
                return firstValue;
            if (firstValue == secondValue)
                return firstValue;
            if (firstValue == 1 || secondValue == 1)
                return 1;
            if (firstValue % 2 == 0 && secondValue % 2 == 0)
                result = 2 * BinaryGCDImplementation(firstValue / 2, secondValue / 2);
            if (firstValue % 2 == 0 && secondValue % 2 == 1)
                result = BinaryGCDImplementation(firstValue / 2, secondValue);
            if (firstValue % 2 == 1 && secondValue % 2 == 0)
                result = BinaryGCDImplementation(firstValue, secondValue / 2);
            if (firstValue % 2 == 1 && secondValue % 2 == 1)
                if (secondValue > firstValue)
                    result = BinaryGCDImplementation((secondValue - firstValue) / 2, firstValue);
                else
                    result = BinaryGCDImplementation((firstValue - secondValue) / 2, secondValue);

            return result;
        }

        private static int EuclidianCallWith2Params(out long elapsedMilliseconds, string method, int firstValue, int secondValue)
        {
            int result = 0;
            elapsedMilliseconds = 0;

            timer.Restart();
            result = EuclidianMethods[method](Math.Abs(firstValue), Math.Abs(secondValue));
            timer.Stop();
            elapsedMilliseconds = timer.ElapsedMilliseconds;

            return result;
        }

        public static int EuclidianCallWith3Params(out long elapsedMilliseconds, string method,int firstValue, int secondValue, int thirdValue)
        {
            int result = 0;
            elapsedMilliseconds = 0;

            timer.Restart();
            result = EuclidianMethods[method](EuclidianMethods[method](Math.Abs(firstValue), Math.Abs(secondValue)), Math.Abs(thirdValue));
            timer.Stop();
            elapsedMilliseconds = timer.ElapsedMilliseconds;

            return result;
        }

        private static int EuclidianCallWithParams(out long elapsedMilliseconds, string method, params int[] values)
        {
            int result = 0;
            elapsedMilliseconds = 0;

            if (values == null)
                throw new ArgumentNullException($"parameter {nameof(values)} is null");
            if (values.Length < 2)
                throw new ArgumentException("There's lack of parameters");
            timer.Restart();
            result = Math.Abs(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                result = EuclidianMethods[method](result, Math.Abs(values[i]));
            }
            timer.Stop();
            elapsedMilliseconds = timer.ElapsedMilliseconds;

            return result;
        }
    }
}
