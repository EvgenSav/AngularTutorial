using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace AngularTutorialWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "http://localhost:3005/";
            using (WebApp.Start<Startup>(baseUrl))
            {
                Console.WriteLine("Web api started");
                Console.ReadLine();
            }
        }
    }
}
