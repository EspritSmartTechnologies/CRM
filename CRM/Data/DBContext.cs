using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data
{
    class DBContext : DbContext

    {
        public DBContext() : base("DBContext") { }
       
    }

}
