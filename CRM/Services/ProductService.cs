﻿using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entities;

namespace Services
{
    public class ProductService : Service<Product>, IProductService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);

        public ProductService() : base(utk)
        {
        }

        public ProductService GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductService product)
        {
            throw new NotImplementedException();
        }
    }
}
