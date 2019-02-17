using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace TicklePrinters
{
    class Program
    {
        static void Main(string[] args)
        {
            // from https://blog.bitscry.com/2017/05/30/appsettings-json-in-net-core-console-app/
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            // loop through IP addresses in appsettings.json file
            //var addresses = configuration.GetSection("printerIPAddresses").Get<List<string>>();
            var addresses = configuration.GetSection("printerIPAddresses").Get<List<string>>();
            foreach (var addr in addresses)
            {
                MainAsync(addr).ConfigureAwait(false).GetAwaiter().GetResult();    
            }
            //MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        
        async static Task MainAsync(string address)
        {
            //Console.WriteLine("Hello World!");

            // from https://dotnetcoretutorials.com/2018/02/27/loading-parsing-web-page-net-core/
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"http://{address}/");
            var pageContents = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(pageContents);
            //Console.ReadLine();
        }
    }
}
