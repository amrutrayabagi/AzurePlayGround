using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin.Hosting;
using OwinAngularWebTest.App_Start;

namespace OwinWebSelfHosted
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseUrl = "http://localhost:5001/";

            using (WebApp.Start<Startup>(new StartOptions(baseUrl)))
            {
                Console.WriteLine("Press Enter to quit.");
                Console.ReadKey();
            }
        }
    }
}
