using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PeopleDataLoaderAgent
{
    public static class Loader
    {

        public static string Folder { get; set; }

        public static int ProcCount { get; set; } = 100;

        static XmlSerializer xs = new XmlSerializer(typeof(UserPatch));
       
        public static void GetData(Action<UserPatch> DataAction)
        {
            var files = Directory.GetFiles(Folder);
            foreach(var f in files)
            {
                FileStream fs = new FileStream(f, FileMode.Open);
                UserPatch data = xs.Deserialize(fs) as UserPatch;
                DataAction(data);
                fs.Close();
            }
        }

        public static void FetchData(HPUserDetail people,int level,Func<bool> Recursion,Action<HPUserDetail,int> UserAction)
        {
            
            //if (level >= 8)
            //    return;
            SearchInfo s = PeopleFinderHelper.GetOrganization(people.uid,0);
            if(s!=null && s.result.Count>0)
            {
                UserPatch patch = new UserPatch();
                patch.Level = level;
                patch.People = people;
                patch.Employees = s.result;
                Save(patch);
                level++;
                foreach (var p in s.result)
                {
                    var isContinue = Recursion();
                    
                    if(isContinue)
                    {
                        FetchData(p, level,Recursion,UserAction);
                    }
                    else
                    {
                        UserAction(p,level);
                    }
                    
                }
                //Parallel.ForEach<HPUserDetail>(s.result, (p) =>
                //{
                //    Count++;
                //    FetchData(p, level);
                //});


            }
            return;
            
        }

        public static void SplitTask(HPUserDetail user,int level)
        {
            var data = PeopleFinderHelper.GetOrganization(user.uid, 0);
            if(data.result != null && data.result.Count>0)
            {
                UserPatch patch = new UserPatch();
                patch.People = user;
                patch.Employees = data.result;
                patch.Level = level;
                Loader.Save(patch);
                foreach (var d in data.result)
                {
                    var arr = new string[] { d.uid, "7" };
                    string args = string.Join(" ", arr);
                    StartProcess("PeopleDataLoaderAgent.exe", args);

                }

            }
            
        }

        public static bool IsTaskSplit()
        {
            if(Process.GetProcessesByName("PeopleDataLoaderAgent").Count()>ProcCount)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

       

        public static void StartProcess(string processName,string args)
        {
            string psName = processName.Split('.').First();
            int pCount = Process.GetProcessesByName(psName).Count();
            if(pCount<ProcCount)
            {
                Process.Start(processName, args);
                return;
            }
            else
            {
                Task.Delay(10000).Wait();
                StartProcess(processName, args);
            }
        }

        public static void Save(UserPatch patch)
        {
            FileStream fs = new FileStream(Path.Combine(Folder, patch.People.uid+".xml"), FileMode.CreateNew);
            xs.Serialize(fs, patch);
            fs.Dispose();
            
        }
    }
}
