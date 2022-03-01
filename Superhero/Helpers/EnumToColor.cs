using Superhero.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Superhero.Helpers
{
    public class EnumToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Types t = (Types) value;

            if (t == Types.bad)
            {
                return Brushes.LightPink;
            }
            else if (t == Types.good)
            {
                return Brushes.LightGreen;
            }
            else
            {
                return Brushes.Yellow;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
