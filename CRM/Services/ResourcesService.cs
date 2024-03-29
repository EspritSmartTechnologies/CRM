﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entities;
using Service.Pattern;

namespace Services
{
   public class ResourcesService : Service<Resources>, IResourcesService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);

        public ResourcesService() : base(utk)
        {
        }
    
    }


}
