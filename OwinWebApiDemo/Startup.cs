using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Owin.Hosting;
using Owin;
using System.Web.Http;

namespace OwinWebApiDemo
{
    class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(

                name: "DefaultRoute",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Index", action = "Index", id = RouteParameter.Optional, }
            );
            appBuilder.UseWebApi(config);
        }

        static void Main(string[] args)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            //client.PostAsync("", new System.Net.Http.StringContent("", Encoding.UTF8, ""));
            using (WebApp.Start<Startup>("http://127.0.0.1:8080"))
            //使用+可以绑定所有地址
            //using (WebApp.Start<Startup>("http://+:8080"))
            {
                Console.WriteLine("Owin WebApp is running......");
                Console.ReadLine();
            }
        }
    }
}
