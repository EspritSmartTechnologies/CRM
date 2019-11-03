using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Service.Pattern;
using Domain.Entities;


namespace Services
{
    public class ResponseService : Service<Response>, IResponseService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);

        public ResponseService() : base(utk)
        {
        }
    }
}