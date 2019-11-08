using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class Promo_ClientPromoConfig:EntityTypeConfiguration<Promotion>
    {
        public Promo_ClientPromoConfig()
        {
            HasMany(c => c.CP)
                  .WithRequired(ct => ct.promotion)
                  .HasForeignKey(ct => ct.PromotionId)
                  .WillCascadeOnDelete(true);


            HasMany(c => c.produits)
                 .WithRequired(ct => ct.promo)
                 .HasForeignKey(ct => ct.promo_Id)
                 .WillCascadeOnDelete(true);

        }
    }
}
