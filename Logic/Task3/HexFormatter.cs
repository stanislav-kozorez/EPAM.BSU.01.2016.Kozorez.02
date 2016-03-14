using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class HexFormatter: IFormatProvider, ICustomFormatter
    {
        private readonly List<Type> supportedTypes;

        public HexFormatter()
        {
            supportedTypes = new List<Type>()
            {
                typeof(sbyte),
                typeof(byte),
                typeof(int),
                typeof(short),
                typeof(long),
                typeof(ushort),
                typeof(uint),
                typeof(ulong)
            };
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string hexFormat = string.Empty;
            string resultFormat = string.Empty;
            string prefix = string.Empty;

            if (!supportedTypes.Contains(arg.GetType()))
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            if (!String.IsNullOrEmpty(format))
                hexFormat = format.Length > 1 ? format.Substring(0, 1) : format;
            if (Double.Parse(arg.ToString()) < 0)
            {
                prefix = "-";
                arg = long.Parse(arg.ToString()) * -1;
            }
            if (hexFormat == "H")
            {
                prefix += "0X";
                resultFormat = "{0:X}";
            }
            else
                if (hexFormat == "h")
                {
                    prefix += "0x";
                    resultFormat = "{0:x}";
                }
                else
                {
                    try
                    {
                        return HandleOtherFormats(format, arg);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                    }
                }

            return prefix + String.Format(resultFormat, arg);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
}
