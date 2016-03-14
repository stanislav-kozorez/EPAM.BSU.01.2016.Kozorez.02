using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class CustomerExtentions
    {
        public static string ToStringExt(this Cusomer arg, string format, IFormatProvider provider)
        {
            StringBuilder sb = new StringBuilder();

            if (String.IsNullOrEmpty(format))
                format = "G";
            if (provider == null)
                provider = CultureInfo.CurrentCulture;
            foreach (var fChar in format)
                switch (Char.ToUpperInvariant(fChar))
                {
                    case 'G':
                        sb.Append(String.Format("Name: {0}\nTelephone: {1}\nRevenue: {2}", arg.Name, arg.ContactPhone, arg.Revenue));
                        break;
                    case 'N':
                        sb.Append("Name: " + arg.Name.ToString(provider));
                        break;
                    case 'T':
                        sb.Append(String.Format("[{0:+### ### ### ###}]", arg.ContactPhone));
                        break;
                    case 'R':
                        sb.Append(String.Format(provider, "{0:C}", arg.Revenue));
                        break;
                    case 'X':
                        sb.Append(String.Format(provider, "<customer>\n\t<name>{0}</name>\n\t<telephone>{1:+(###) ###-###-###}</telephone>\n\t<revenue>{2:C}</revenue>\n</customer>", arg.Name, arg.ContactPhone, arg.Revenue));
                            break;
                    default:
                        throw new FormatException(String.Format("The {0} format string is not supported.", format));
                }
            return sb.ToString();
        }
    }
}
