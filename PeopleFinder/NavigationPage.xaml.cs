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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace PeopleFinder
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class NavigationPage : Page
    {
        public static NavigationPage Current;
        public static Frame RootFrame = null;
        public static SplitView RootSplitView
        {
            get
            {
                return Current.rootSplitView;
            }
        }

        public NavigationPage()
        {
            this.InitializeComponent();
            Current = this;
            RootFrame = this.rootFrame;
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            this.rootFrame.Navigate(typeof(MainPage));
            rootSplitView.IsPaneOpen = false;
        }

        private void btn_PeopleFinder_Click(object sender, RoutedEventArgs e)
        {
            this.rootFrame.Navigate(typeof(PeoplePage));
            rootSplitView.IsPaneOpen = false;
        }

        
    }
}
