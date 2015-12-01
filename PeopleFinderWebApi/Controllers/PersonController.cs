using PeopleFinderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace PeopleFinderWebApi.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(SearchInfo))]
        public async Task<IHttpActionResult> Search(string type, string search)
        {

            var result = await PeopleFinderHelper.Search(search);
            return Ok<SearchInfo>(result);
        }

       



        [HttpGet]

        public async Task<IHttpActionResult> Detail(string id)
        {
            var result = await PeopleFinderHelper.GetDetail(id);
            return Ok<SingleInfo>(result);
        }

        [HttpGet]

        public async Task<IHttpActionResult> Organization(string id)
        {
            var result = await PeopleFinderHelper.GetOrganization(id);
            return Ok<SearchInfo>(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Mgr(string id)
        {
            var result = await PeopleFinderHelper.GetManagers(id);
            return Ok<MgrInfo>(result);
        }


    }
}
