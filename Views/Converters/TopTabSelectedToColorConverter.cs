using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using TabViewControl;

namespace TabViewControl.Views.Converters
{
    public class TopTabSelectedToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter as string == "frame")//frame
            {
                if (value is bool boolValue)
                {

                    if (boolValue)
                        return (Color)App.Current.Resources["DefaultTextColor"];
                }
                return Colors.Transparent;
            }
            else if (parameter as string == "label")//frame
            {
                if (value is bool boolValue)
                {

                    if (boolValue)
                        return (Color)App.Current.Resources["ActiveButtonTextColor"];
                }
                return (Color)App.Current.Resources["DefaultTextColor"];
            }
            else throw new ArgumentException("parameter must be frame or label");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
