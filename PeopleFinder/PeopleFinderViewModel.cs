using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleFinder
{
    public class PeopleFinderViewModel
    {
        public string Group { get; set; }

        public List<HPUserDetail> Peoples { get; set; }

        public int Count
        {
            get { return Peoples.Count; }
        }
    }
}
