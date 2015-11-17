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

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace PeopleFinder
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPageTemp : Page
    {
        public MainPageTemp()
        {
            this.InitializeComponent();
            autoBox_Search.ItemsSource = emailList;
        }

       

        private async void getData(string mail,HPUserDetail bossData = null)
        {
            if(!string.IsNullOrEmpty(mail))
            {
                //"search?type=auto&search={0}"
                string orgApi = string.Format("organization/uid={0},ou=People,o=hp.com", mail);
                string api = string.Format("detail/{0}", mail);


                var u = await HttpHelper.GetInfo<SearchInfo>(orgApi);
                
                hs_Result.DataContext = u.result;

                if(bossData==null)
                {
                    var boss = await HttpHelper.GetInfo<SingleInfo>(api);
                    hs_Boss.DataContext = boss?.result;
                }
                else
                {
                    hs_Boss.DataContext = bossData;
                }
                
            }
            
        }

       

        private void GridView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var obj = (sender as GridView).SelectedItem as HPUserDetail;
            getData(obj?.uid,obj);
        }

       

        private void hs_Boss_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var obj = hs_Boss.DataContext as HPUserDetail;
            string mail = obj?.manager.Split(',').First().Replace("uid=", "");
            getData(mail);
        }

        private void autoBox_Search_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = args.SelectedItem.ToString();
            getData(sender.Text);
        }

        private void autoBox_Search_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            
            if(args.ChosenSuggestion != null)
            {
                getData(args.ChosenSuggestion.ToString());
                emailList.Add(args.ChosenSuggestion.ToString());
            }
            else
            {
                getData(args.QueryText);
                emailList.Add(args.QueryText);
            }
            
        }


        List<string> emailList = new List<string>();

        private void autoBox_Search_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if(args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                sender.ItemsSource = emailList.Where(c => c.IndexOf(sender.Text) > -1).OrderBy(c => c).ToList();
            }
        }
    }
}
