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

            List<Gariunai_Cloud_Services.Entities.Business> res = DatabaseHelper.GetBusinesses();
            System.Diagnostics.Debug.WriteLine(res.Count());

            foreach (var shop in DatabaseHelper.GetBusinesses()) 
            {
                System.Diagnostics.Debug.WriteLine("-------------------------");
                System.Diagnostics.Debug.WriteLine("shop name = " + shop.Name);
                System.Diagnostics.Debug.WriteLine("shop description  = " + shop.Description);
                System.Diagnostics.Debug.WriteLine("Owner name = " + shop.Owner.Name);
                System.Diagnostics.Debug.Write("Products = ");
                foreach(var product in shop.Produce) 
                {
                    System.Diagnostics.Debug.Write(product + " ");
                }
                System.Diagnostics.Debug.Write("\n");
            }
/*
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LocalProduceForm());*/
        }
    }
}
