using CourseEFCore.Domain;
using CourseEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            using var db = new Data.ApplicationContext();
            db.Database.Migrate();
            var exist = db.Database.GetPendingMigrations().Any();
            if (exist)
            {
                
            }
            */

            //Console.WriteLine("Hello World!");
            //AddData();
            //GetData();
            //RegisterOrder();
            //GetOrderEarlyLoading();
            //UpdateData();

            DeleteRecord();
        }

        private static void DeleteRecord()
        {
            using var db = new Data.ApplicationContext();
            var client = db.Clients.Find(3);
            //db.Clients.Remove(client);
            //db.Remove(client);
            db.Entry(client).State = EntityState.Deleted;

            db.SaveChanges();
        }


        private static void UpdateData()
        {
            using var db = new Data.ApplicationContext();
            var client = db.Clients.Find(2);
            client.Name = "Client updated step 1";

            var disconectedClient = new
            {
                Name = "Disconected client step 3",
                Phone = "987654321"
            };

            db.Attach(client);
            db.Entry(client).CurrentValues.SetValues(disconectedClient);

            //db.Clients.Update(client);
            db.SaveChanges();
        }
        


        private static void GetOrderEarlyLoading()
        {
            using var db = new Data.ApplicationContext();
            var orders = db.Orders
                .Include(p=>p.Items)
                .ThenInclude(p=>p.Product)
                .ToList();

            Console.WriteLine(orders.Count);
        }

        private static void RegisterOrder()
        {
            using var db = new Data.ApplicationContext();

            var client = db.Clients.FirstOrDefault();
            var product = db.Products.FirstOrDefault();

            var order = new Order
            {
                ClientId = client.Id,
                StartedIn = DateTime.Now,
                FinishedIn = DateTime.Now,
                Observation = "Order Test",
                Status = OrderStatus.Review,
                DeliveryType = DeliveryType.NoDelivery,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId = product.Id,
                        Discount = 0,
                        Quantity = 1,
                        Price = 10,
                    }
                }
            };

            db.Orders.Add(order);

            db.SaveChanges();
        }


        private static void GetData()
        {
            using var db = new Data.ApplicationContext();
            //var getBySintaxe = (from c in db.Clients where c.Id > 0 select c).ToList();
            var getByMethod = db.Clients.AsNoTracking().Where(c=>c.Id >0).ToList();
            foreach (var client in getByMethod)
            {
                Console.WriteLine($"Getting Client: {client.Id}");
                db.Clients.Find(client.Id);
            }
        }

        private static void AddData()
        {
            var product = new Product
            {
                Description = "Product test",
                BarCode = "123456789",
                Price = 10m,
                ProductType = ProductType.Resale,
                Active = true
            };

            var client = new Client
            {
                Name = "Rudy Silva",
                PostCode = "123456",
                State = "NSW",
                Phone = "123456",
                Email = "rudy@email.com",
                City = "Sydney"
            };


            using var db = new Data.ApplicationContext();
            db.AddRange(product, client);

            //db.Products.Add(product);
            //db.Set<Product>().Add(product);
            //db.Entry(product).State = EntityState.Added;
            //db.Add(product);

            int records = db.SaveChanges();
            Console.WriteLine("Total Record(s): " + records);

        }
    }
}
