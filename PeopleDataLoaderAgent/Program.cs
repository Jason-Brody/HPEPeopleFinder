using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataLoaderAgent
{
    class Program
    {
        static void Main(string[] args)
        {
            Loader.Folder = @"D:\PeopleData";
            
            try
            {
                Console.WriteLine(args[0]);
                Loader.FetchData(new HPUserDetail() { uid = args[0] }, int.Parse(args[1]),
                    () => {
                        string msg = $"{args[0]}\n{args[1]}";
                        Console.Clear();
                        Console.WriteLine(msg);
                        return Loader.IsTaskSplit();
                    },
                    (u,i) => {
                        Loader.SplitTask(u, i);
                });
                Console.WriteLine("Finished");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            

        }

        //public static void Load()
        //{
        //    Loader.Folder = @"D:\PeopleData";
        //    Loader.FetchData(new HPUserDetail() { uid = "sheng.xu@hpe.com" }, 6);
        //}
    }
}
