using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Launcher.Pages
{
    internal class AccountProfilePageTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string userName = (string)value;

#if true
            if (string.IsNullOrEmpty(userName)) return "Profile";

            if (userName.EndsWith("s", true, culture))
                return $"{userName}' Profile";
            else
                return $"{userName}'s Profile";
#else
            return $"{userName} 账户信息";
#endif
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
