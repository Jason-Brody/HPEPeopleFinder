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
// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace PeopleFinder
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PeopleDetailPage : Page
    {
        public PeopleDetailPage()
        {
            this.InitializeComponent();
            
        }

        public HPUserViewModel ViewModel { get; set; }

        public Dictionary<string,string> Infoes { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel = new HPUserViewModel(e.Parameter as HPUserDetail);
            Infoes = ViewModel.ToDic();
            
        }
    }
}
