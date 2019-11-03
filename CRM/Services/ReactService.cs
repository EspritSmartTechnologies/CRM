using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entities;
using Service.Pattern;

namespace Services
{
    public class ReactService : Service<React>, IReactService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);

        public ReactService() : base(utk)
        {
        }
    
    }
}

