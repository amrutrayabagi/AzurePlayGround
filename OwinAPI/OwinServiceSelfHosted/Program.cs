using Microsoft.Owin.Hosting;
using OwinApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinServiceSelfHosted
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseUrl = "http://localhost:5002/";

            using (WebApp.Start<StartUp>(new StartOptions(baseUrl)))
            {
                Console.WriteLine("Press Enter to quit.");
                Console.ReadKey();
            }
        }
    }
}
