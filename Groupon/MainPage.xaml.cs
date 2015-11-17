using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Utils;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Groupon
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            
        }

        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _cls = DataSource.GetData();
        }

        private List<ClassRoom> _cls;

        public List<ClassRoom> Classes
        {
            get
            {
                return _cls;
            }
        }

        private void btn_GetCity_Click(object sender, RoutedEventArgs e)
        {
            
            HttpClientHelper.BaseURL = "http://apis.baidu.com/baidunuomi/openapi/";
            //var cityInfo = await HttpClientHelper.GetInfo<CityInfo>("cities",new Dictionary<string, string>() { { "apikey", "468ab24bc90d8d69b6621174141b71d2" } });
            //var obj = (from c in cityInfo.cities group c by c.city_id.Substring(0, 5) into cp select cp).ToList();
            //var stus = DataSource.GetStudents();
            //Cities.Source = from s in stus group s by s.Name into g select g;
            // Cities.Source = DataSource.GetData();
        }
    }
}
