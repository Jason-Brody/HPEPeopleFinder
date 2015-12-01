using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PeopleDataLoaderAgent;

namespace PeopleDataLoader
{
    class HPUserContext:DbContext
    {
        public HPUserContext():base("Test")
        {

        }

        public DbSet<HPUserDetail> HPUserDetails { get; set; }

       
    }
}
