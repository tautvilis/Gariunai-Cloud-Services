using Gariunai_Cloud_Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            User user = new User
            {
                Name = "Janina Janiniene",
                Email = "mociute@gmail.com",
                Description = "Turiu 30 metu arbatos rinkimo patirties :)"
            };

            Business business = new Business
            {
                Owner = user,
                Name = "Mociutes arbatzoles",
                Description = "Skanu, pigu, sveika",
                Produce = new List<string> { "Ciobreliai", "Liepu ziedai", "Dilgeles", "Pelynai" }
            };

            DatabaseHelper.AddShopToDB(business);

          /*  Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LocalProduceForm());*/
        }
    }
}
