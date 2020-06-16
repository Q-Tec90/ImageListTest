using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace ImageListTest
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource xValue = null;
            try
            {
                if (value != null)
                {
                    MemoryStream mem = new MemoryStream((byte[])value);
                    xValue = ImageSource.FromStream(new Func<Stream>(() => { return mem; }));
                }

            }
            catch (Exception ex)
            {

            }
            return xValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
