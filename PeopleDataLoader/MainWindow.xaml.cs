using PeopleDataLoaderAgent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeopleDataLoader
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            //GetFile();
            Read();
            //Loader.Folder = @"D:\PeopleData";

            //string uid = "robert.youngjohns@hpe.com";
            //int level = 2;
            //var data = PeopleFinderHelper.GetOrganization(uid, 0);
            //UserPatch patch = new UserPatch();
            //patch.People = new HPUserDetail() { uid = uid };
            //patch.Employees = data.result;
            //patch.Level = level;
            //Loader.Save(patch);
            //foreach (var d in data.result)
            //{
            //    var arr = new string[] { d.uid, (level + 1).ToString() };
            //    string args = string.Join(" ", arr);
            //    Process.Start("PeopleDataLoaderAgent.exe", args);
            //}


            //tbl_Start.Text = DateTime.Now.ToString();

            //Read();
            //tbl_End.Text = DateTime.Now.ToString();
            //tbl_Total.Text = Loader.Count.ToString();
        }

        public void GetFile()
        {
            //string folder = @"D:\robert.mao@hpe.com";
            string folder = @"D:\PeopleData";
            string fileName = "";
            foreach(var f in Directory.GetFiles(folder))
            {
                FileInfo fi = new FileInfo(f);
                fileName += fi.Name + ",";
            }
        }
        //public void Load()
        //{
        //    Loader.Folder = @"D:\PeopleData";
        //    Loader.FetchData(new HPUserDetail() { uid = "john.hinshaw@hpe.com" }, 2);
        //}

        public void Read()
        {
            Loader.Folder = @"D:\PeopleData";
            HPUserContext db = new HPUserContext();
            Loader.GetData((d) => {
                foreach(var data in d.Employees)
                {
                    data.Level = d.Level + 1;
                    db.HPUserDetails.Add(data);
                }
                db.SaveChanges();
            });
        }
    }
}
