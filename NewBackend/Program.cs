using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace NewBackend
{
    public class Program
    {
        public  static void Main(string[] args)
        {

            //  var ctx = new NewBackendDbContext();


            //  var books =  ctx.Books.ToList();



            //  foreach (var item in books)
            //  {
            //      System.Console.WriteLine(item.FavouritesUserBooks);
            //  }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
