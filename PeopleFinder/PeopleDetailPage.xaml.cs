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
using System.Threading.Tasks;
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

        
        public Queue<HPUserDetail> Managers { get; set; }
        //public List<HPUserDetail> Managers { get; set; }

        private HPUserDetail me;

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel = new HPUserViewModel(e.Parameter as HPUserDetail);
            me = e.Parameter as HPUserDetail;
            Infoes = ViewModel.ToDic();
            

            lv_Mgr.Opacity = 0;
            processBar.Opacity = 1;
            processBar.IsIndeterminate = true;

            var result = await PeopleFinderHelper.GetManagers(ViewModel.Uid);
            Managers = new Queue<HPUserDetail>();
            Managers.Enqueue(me);
            //Managers = new List<HPUserDetail>();
            foreach (var r in result.result)
            {
                Managers.Enqueue(r.First());
                //Managers.Add(r.First());
            }
            
            this.Bindings.Update();
            processBar.IsIndeterminate = false;
            processBar.Opacity = 0;
            lv_Mgr.Opacity = 1;
            
        }

        private void btn_SendMail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_SendMsg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ShowMgr_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void topAppBar_Opened(object sender, object e)
        {

        }

        private void lv_Mgr_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var people = (sender as GridView).SelectedItem as HPUserDetail;


            if(people!=null)
            {
                ViewModel = new HPUserViewModel(people);
                Infoes = ViewModel.ToDic();
                this.Bindings.Update();


                //while(Managers.Count>0)
                //{
                //    var manager = Managers.Dequeue();
                //    if(string.Compare(people.employeeNumber,manager.employeeNumber)==0)
                //    {
                //        ViewModel = new HPUserViewModel(people);
                //        Managers = new Queue<HPUserDetail>(Managers);
                //        Infoes = ViewModel.ToDic();
                //        this.Bindings.Update();
                //        break;
                //    }
                //}
            }
        }
    }
}
