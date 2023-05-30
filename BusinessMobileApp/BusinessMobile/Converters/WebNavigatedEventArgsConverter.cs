using CommunityToolkit.Maui.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessMobile.Converters
{
    public class WebNavigatedEventArgsConverter : BaseConverterOneWay<WebNavigatedEventArgs, object>
    {
        public override object DefaultConvertReturnValue { get; set; }

        public override object ConvertFrom(WebNavigatedEventArgs value, CultureInfo culture = null) => value switch
        {
            null => null,
            _ => value
        };
    }
}
