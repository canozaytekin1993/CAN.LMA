using System.Collections.Generic;
using CAN.LMA.WebUI.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CAN.LMA.WebUI.Data
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryManagementDbContext>();

                #region Customer Add

                var justin = new Customer {Name = "Justin Noon"};

                var willie = new Customer {Name = "Willie Parodi"};

                var leona = new Customer {Name = "Leona Gosse"};

                context.Customers.Add(justin);
                context.Customers.Add(willie);
                context.Customers.Add(leona);

                #endregion

                #region Author

                var authorDeMarco = new Author
                {
                    Name = "M 3 DeMarco",
                    Books = new List<Book>
                    {
                        new Book {Title = "The Millionaire Fastlane"},
                        new Book {Title = "Unscripted"}
                    }
                };

                var authorCardone = new Author
                {
                    Name = "Grant Cardone",
                    Books = new List<Book>
                    {
                        new Book {Title = "The 10x Rule"},
                        new Book {Title = "If You're Not First, You're Last."},
                        new Book {Title = "Sell To Survive"}
                    }
                };

                context.Authors.Add(authorDeMarco);
                context.Authors.Add(authorCardone);

                #endregion

                context.SaveChanges();
            }
        }
    }
}