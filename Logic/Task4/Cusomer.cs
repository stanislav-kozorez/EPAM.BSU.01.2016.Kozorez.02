using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Cusomer: IFormattable
    {
        private string name;
        private ulong contactPhone;
        private decimal revenue;

        public string Name { get {return name; } set { name = value; } }
        public ulong ContactPhone { get { return contactPhone; } set { contactPhone = value; } }
        public decimal Revenue { get { return revenue; } set { revenue = value; } }

        public Cusomer(string name, ulong contactPhone, decimal revenue)
        {
            this.name = name;
            this.contactPhone = contactPhone;
            this.revenue = revenue;
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            StringBuilder sb = new StringBuilder();

            if (String.IsNullOrEmpty(format))
                format = "G";
            if (provider == null)
                provider = CultureInfo.CurrentCulture;
            foreach(var fChar in format)
                switch (Char.ToUpperInvariant(fChar))
                {
                    case 'G':
                        sb.Append(String.Format("Name: {0}\nTelephone: {1}\nRevenue: {2}", name, contactPhone, revenue));
                            break;
                    case 'N':
                        sb.Append(name.ToString(provider));
                            break;
                    case 'T':
                        sb.Append(String.Format("{0:+(###) ###-###-###}", contactPhone));
                            break;
                    case 'R':
                        sb.Append(String.Format(provider, "{0:C}", revenue));
                            break;
                    default:
                        throw new FormatException(String.Format("The {0} format string is not supported.", format));
                }
            return sb.ToString();
        }
    }
}
