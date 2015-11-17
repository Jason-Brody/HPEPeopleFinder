using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class PeoplePage : Page
    {
        List<string> searchHistory = new List<string>();
        public IEnumerable<PeopleFinderViewModel> ViewModel { get; set; }
        public PeoplePage()
        {

            
            this.InitializeComponent();
            
            

        }

        ///C:\Users\Young\AppData\Local\Packages\42298834-c3b6-47bd-9aec-b97930161d35_n8azgcm9zr0gy\LocalState
        async Task<List<PeopleFinderViewModel>> loadData()
        {
            return await XmlSerializationHelper.ReadObjectFromXmlFileAsync<List<PeopleFinderViewModel>>("1.xml");
        }

       async void load()
        {
            ViewModel = await XmlSerializationHelper.ReadObjectFromXmlFileAsync<List<PeopleFinderViewModel>>("1.xml");
        }

        private void asbox_Search_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }
     
       

        private async void asbox_Search_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {


            Func<HPUserDetail, string> f = h => h.ou;

            setWorking(true);

            string searchText = args.ChosenSuggestion == null ? args.QueryText : args.ChosenSuggestion.ToString();

            var result = await PeopleFinderHelper.Search(searchText);
            
            var myResult = result?.result.GroupBy(g => g.co).OrderBy(o => o.Key).Select(gu => new PeopleFinderViewModel() { Group = gu.Key, Peoples = gu.ToList() });
            ViewModel = myResult;

         
            this.Bindings.Update();

            setWorking(false);




        }



        private void asbox_Search_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private void setWorking(bool isWorking)
        {
            process.IsActive = isWorking;
            process.Opacity = isWorking ? 1 : 0;
            
        }

        private void btn_ShowPanel_Click(object sender, RoutedEventArgs e)
        {
            NavigationPage.RootSplitView.IsPaneOpen = true;
        }

        

        private void GridView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            var people = (sender as GridView).SelectedItem as HPUserDetail;
            if(people!=null)
            {
                NavigationPage.RootFrame.Navigate(typeof(PeopleDetailPage), people);
                //sz_Result.Opacity = 0;
                //string api = $"http://peoplefinder.als.hos.hpecorp.net/#!/People/uid={people.uid},ou=People,o=hp.com";
                //wv_Detail.Navigate(new Uri(api));
            }
            
            
        }
    }
}
