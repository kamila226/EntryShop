using EntryShop.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Linq;

namespace EntryShop.Data
{
    public class DbInitializer
    {
        public static void Initialize(ShopContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            var clients = new Client[]
            {
                new Client{ FirstName="Kamila", LastName="Scerbakova", Email="kamila_shc@inbox.lv", Birthdate=new DateTime(1998, 3, 26), Gender=Gender.Female},
                new Client{ FirstName="Edgars", LastName="Egle", Email="edgars_egle@gmail.com", Birthdate=new DateTime(1996, 5, 25), Gender=Gender.Male}
            };

            foreach (Client i in clients)
            {
                context.Clients.Add(i);
            }

            context.SaveChanges();

            var products = new Product[]
            {
                new Product{ Code=1234, Title="Monitor", Price=126.00M },
                new Product{ Code=1235, Title="Tablet", Price=526.99M },
                new Product{ Code=1236, Title="Phone", Price=299.99M },
                new Product{ Code=1237, Title="Computer", Price=326.99M},
                new Product{ Code=1238, Title="Mouse", Price=19.99M}
            };

            foreach (Product i in products)
            {
                context.Products.Add(i);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{
                    ClientID = clients.Single( c => c.FirstName == "Kamila").ID,
                    ProductID = products.Single( p => p.Title == "Mouse" ).ID,
                    Product = products.Single( p => p.Title == "Mouse" ),
                    Quantity = 5,
                    Status = Status.Paid
                },
                new Order{
                    ClientID = clients.Single( c => c.FirstName == "Edwina").ID,
                    ProductID = products.Single( p => p.Title == "Computer" ).ID,
                    Product = products.Single( p => p.Title == "Computer" ),
                    Quantity = 2,
                    Status = Status.Delivered
                },
                new Order{
                    ClientID = clients.Single( c => c.FirstName == "Kamila").ID,
                    ProductID = products.Single( p => p.Title == "Phone" ).ID,
                    Product = products.Single( p => p.Title == "Phone" ),
                    Quantity = 8,
                    Status = Status.Delivered
                },
                new Order{
                    ClientID = clients.Single( c => c.FirstName == "Kamila").ID,
                    ProductID = products.Single( p => p.Title == "Tablet" ).ID,
                    Product = products.Single( p => p.Title == "Tablet" ),
                    Quantity = 3,
                    Status = Status.Delivered
                }
            };

            foreach (Order i in orders)
            {
                context.Orders.Add(i);
            }
            context.SaveChanges();
        }
    }
}
