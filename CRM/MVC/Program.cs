using Data.Infrastructure;
using Domain.Entities;
using Service.Pattern;
using System;

namespace MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork uow = new UnitOfWork(Factory);
            IService<Client> serClient = new Service<Client>(uow);

            Client c1 = new Client()
            {
                nom = "amani",
                prenom = "ayadi",
                num_tel = 54501557,
                Adress = "cite amen",

                nombre_carte_rechange = 2398


            };
            Client c2 = new Client()
            {
                nom = "sou",
                prenom = "chem",
                num_tel = 27999888,
                Adress = "ariana",

                nombre_carte_rechange = 5690


            };
            serClient.Add(c1);
            serClient.Add(c2);
            IService<Periode> serPeriode = new Service<Periode>(uow);


            Periode p1 = new Periode()
            {

                date_deb = new DateTime(2019, 11, 05, 8, 30, 52),
                date_fin = new DateTime(2019, 11, 30, 8, 30, 52),
                saison = "printemps"

            };
            Periode p2 = new Periode()
            {
                date_deb = new DateTime(2019, 12, 5, 8, 30, 52),
                date_fin = new DateTime(2020, 02, 1, 8, 30, 52),
                saison = "hiver"

            };
            serPeriode.Add(p1);
            serPeriode.Add(p2);



            IService<ZoneGeographique> serZone = new Service<ZoneGeographique>(uow);
            ZoneGeographique z1 = new ZoneGeographique()
            {
                pays = "Tunis",
                gouvernorat = "bizerte",
                ville = "ghar melah"

            };
            ZoneGeographique z2 = new ZoneGeographique()
            {
                pays = "Tunis",
                gouvernorat = "ariana",
                ville = "ariana soghra"

            };
            serZone.Add(z1);
            serZone.Add(z2);

            IService<Promotion> serpromo = new Service<Promotion>(uow);
            Promotion promo1 = new Promotion()
            {
                nom = "promo ajab",
                Description = "remise de 50 %",
                periode = p1,
                zone = z1

            };
            Promotion promo2 = new Promotion()
            {
                nom = "promo dawa5",
                Description = "remise de 75 %",
                periode = p2,
                zone = z2

            };
            serpromo.Add(promo1);
            serpromo.Add(promo2);

            IService<Client_Promotion> ClPromoSer = new Service<Client_Promotion>(uow);
            Client_Promotion cp1 = new Client_Promotion()
            {
                promotion = promo1,
                client = c1

            };
            Client_Promotion cp2 = new Client_Promotion()
            {
                promotion = promo2,
                client = c2

            };
            ClPromoSer.Add(cp1);
            ClPromoSer.Add(cp2);

            IService<Product> ProdSer = new Service<Product>(uow);
            Product produi1 = new Product()
            {
                nom = "puce Ajab",
                Price = 2000,
                Quantity = 50,
                promo = promo1
            };

            Product produi2 = new Product()
            {
                nom = "puce esperance",
                Price = 2000,
                Quantity = 200,
                promo = promo2
            };
            ProdSer.Add(produi1);
            ProdSer.Add(produi2);
            uow.Commit();
            uow.Dispose();

        }

    }
    }

