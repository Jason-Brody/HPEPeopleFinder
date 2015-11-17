using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PeopleFinder
{
    class CountryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string pic = $"ms-appx:///Flags/{value.ToString()}.png";
            return new BitmapImage(new Uri(pic));
            
            //string pic = string.Format("http://home.hp.com/athp_resources/images/flags/{0}.png", value.ToString().ToLower());
            //return pic;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
