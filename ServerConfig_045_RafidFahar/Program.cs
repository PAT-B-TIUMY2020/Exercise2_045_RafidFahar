using ServiceRest_045_RafidFahar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerConfig_045_RafidFahar
{
    static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public class Server
        {
            public void OnServer()
            {
                ServiceHost hostObj = null;
                try
                {
                    hostObj = new ServiceHost(typeof(TI_UMY));
                    hostObj.Open();
                    Console.WriteLine("Server is Ready!!!");
                    Console.ReadLine();
                    hostObj.Close();
                }
                catch (Exception ex)
                {
                    hostObj = null;
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
            public void OffServer()
            {
                ServiceHost hostObj = null;
                try
                {
                    hostObj = new ServiceHost(typeof(TI_UMY));
                    hostObj.Open();
                    Console.WriteLine("Server is Off!!!");
                    Console.ReadLine();
                    hostObj.Close();
                }
                catch (Exception ex)
                {
                    hostObj = null;
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
