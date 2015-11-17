using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groupon
{
    public class City
    {
        public string city_id { get; set; }
        public string city_name { get; set; }
        public string short_name { get; set; }
        public string city_pinyin { get; set; }
        public string short_pinyin { get; set; }
    }

    public class CityInfo
    {
        public int errno { get; set; }
        public string msg { get; set; }
        public List<City> cities { get; set; }
    }
}
