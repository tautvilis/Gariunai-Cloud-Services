using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Entities;

namespace Gariunai_Cloud_Services
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        private static void Main()
        {
            seed();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm());
        }

        private static void seed()
        {
            User[] users =
            {
                new User {Name = "Admin", Email = "Admin@email.com"},
                new User {Name = "User", Email = "user@mail.com"},
                new User {Name = "Owner1", Email = "ownner1@email.com", Description = "Turiu Parduotuve 1"},
                new User {Name = "Owner2", Email = "ownner2@email.com", Description = "Turiu Parduotuve 2"},
                new User {Name = "Owner3", Email = "ownner3@email.com", Description = "Turiu Parduotuve 3"},
                new User {Name = "Owner4", Email = "ownner4@email.com", Description = "Turiu Parduotuve 4"},
                new User {Name = "Owner5", Email = "ownner5@email.com", Description = "Turiu Parduotuve 5"}
            };
            Shop[] shops =
            {
                new Shop
                {
                    Name = "Braskiu kioskas", Description = "sviezios letuviskos, braskes",
                    Produce = new List<Produce> {new Produce {Name = "Brakses"}}
                },
                new Shop
                {
                    Name = "Mociutes misko uogos", Description = "puikios kokybes misko uogos", Produce =
                        new List<Produce>
                        {
                            new Produce {Name = "Brakses"},
                            new Produce {Name = "Melynes"},
                            new Produce {Name = "Bruknes"},
                            new Produce {Name = "Gervuoges"}
                        }
                },
                new Shop
                {
                    Name = "Baltijos zuvys", Description = "sviezias Baltijos juros laimikis kasdiena", Produce =
                        new List<Produce>
                        {
                            new Produce {Name = "Lasisos"},
                            new Produce {Name = "Eseriai"},
                            new Produce {Name = "Karsiai"},
                            new Produce {Name = "Menkes"}
                        }
                },
                new Shop
                {
                    Name = "Bobutes arbatazoles", Description = "Laiko patikrinta", Produce = new List<Produce>
                    {
                        new Produce {Name = "Pelynai"},
                        new Produce {Name = "Liepos"},
                        new Produce {Name = "Ramuneles"},
                        new Produce {Name = "Dilgeliu arbata"}
                    }
                }
            };
            foreach (var user in users) DatabaseHelper.RegisterUser(user, user.Name);
            DatabaseHelper.RegisterShop(shops[0], "Owner1");
            DatabaseHelper.RegisterShop(shops[1], "Owner2");
            DatabaseHelper.RegisterShop(shops[2], "Owner3");
            DatabaseHelper.RegisterShop(shops[3], "Owner4");
        }
    }
}