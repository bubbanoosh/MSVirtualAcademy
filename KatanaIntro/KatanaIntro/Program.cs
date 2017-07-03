using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(KatanaIntro.StartUp))]
namespace KatanaIntro
{

    using AppFunc = Func<IDictionary<string, object>, Task>;

    /// <summary>
    /// Console Application
    /// </summary>
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        string uri = "http://localhost:8080";

    //        //Basic Katana App
    //        using (WebApp.Start<StartUp>(uri))
    //        {
    //            //F5 run app
    //            Console.WriteLine("Started");

    //            //Browse to http://localhost:8080

    //            //Keep running till someone presses a key
    //            Console.ReadKey();

    //            Console.WriteLine("Stopping Server");
    //        }
    //    }
    //}

        
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {

            //Middleware showing the Request + Response
            app.Use(async (environment, next) =>
            {
                Console.WriteLine("Requesting: " + environment.Request.Path);

                await next();

                Console.WriteLine("Response is : " + environment.Response.StatusCode);
            });


            ConfigureWebApi(app);

            // Microsoft.Owin.Host.Diagnostics
            // This will show Owin Welcome page
            app.UseWelcomePage();



            //// For every http request the console app will respond with 'Hello world'
            //app.Run(ctx =>
            //{
            //    return ctx.Response.WriteAsync("Hellow from StartUp.Configuration app.Run()");
            //});

            //// We've created Middleware
            ////  Dumping out the Environment
            //app.Use( async (environment, next) =>
            //{
            //    foreach (var pair in environment.Environment)
            //    {
            //        Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
            //    }
            //    await next();
            //});
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            // Routing
            config.Routes.MapHttpRoute(
                "DefaultApi", 
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
                );

            // WebApi
            app.UseWebApi(config);
        }
    }

    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
        AppFunc _next;
        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }


        public Task Invoke(IDictionary<string, object> environment) //Next in the pipeline
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello from Program.Invoke");
            }
        }
    }
}
