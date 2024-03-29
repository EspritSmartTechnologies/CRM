﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class ClientConfig : EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            HasMany(c => c.CP)
                  .WithRequired(ct => ct.client)
                  .HasForeignKey(ct => ct.ClientId)
                  .WillCascadeOnDelete(true);
        }
    }
}
