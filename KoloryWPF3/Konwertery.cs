using System;
using System.Windows.Data;
using System.Windows.Media;

namespace KoloryWPF3
{


    public class ByteToDoubleConverter : IValueConverter    
    {
        public object Convert(object value, 
                                Type targetType,
                                object parameter, 
                                System.Globalization.CultureInfo culture)
        {
            return (double)(byte)value;
        }
        public object ConvertBack(object value, 
                                    Type targetType, 
                                    object parameter, 
                                    System.Globalization.CultureInfo culture)
        {
            return (byte)(double)value;
        }
    }

    public class ColorToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            Color kolor = (Color)value;
            return new SolidColorBrush(kolor);
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
        throw new NotImplementedException();
        }
    }

}
