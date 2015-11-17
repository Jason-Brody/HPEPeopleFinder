using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace PeopleFinder
{
    //api references
    //api:detail/yang.zhou4@hpe.com returnType:SingleInfo
    //api:mgr/yang.zhou4@hpe.com returnType:MgrInfo
    //api:search?search=ASIAPACIFIC:yanzhou&type=ntlogin returnType:SearchInfo
    //api:search?type=email&search=miguel.quintero@hp.com returnType:SearchInfo

    internal static class PeopleFinderHelper
    {

        static PeopleFinderHelper()
        {
            HttpClientHelper.BaseURL = "http://peoplefinder-api.corp.hpecorp.net/v1.0/person/";
        }


        public static Task<SearchInfo> Search(string SearchText)
        {
            string api = string.Format("search?type=auto&search={0}",SearchText);
            return HttpClientHelper.GetInfo<SearchInfo>(api);
        }

        public static Task<SingleInfo> GetDetail(string EmailAddress)
        {
            string api = string.Format("detail/{0}", EmailAddress);
            return HttpClientHelper.GetInfo<SingleInfo>(api);
        }

        public static Task<SearchInfo> GetOrganization(string EmailAddress)
        {
            string api = string.Format("organization/uid={0},ou=People,o=hp.com", EmailAddress);
            return HttpClientHelper.GetInfo<SearchInfo>(api);
        }
    }
}
