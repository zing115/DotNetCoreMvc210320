using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Mvc1Autofac.Controllers;
using Mvc1Autofac.Services;

namespace Mvc1Autofac
{
  public class Startup
  {
    /*
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    */
    public Startup(IWebHostEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      this.Configuration = builder.Build();
    }

    //public IConfiguration Configuration { get; }
    public IConfigurationRoot Configuration { get; private set; }
    public ILifetimeScope AutofacContainer { get; private set; }    

    // ConfigureServices is where you register dependencies. This gets
    // called by the runtime before the ConfigureContainer method, below.
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();

      // Add services to the collection. Don't build or return
      // any IServiceProvider or the ConfigureContainer method
      // won't get called. Don't create a ContainerBuilder
      // for Autofac here, and don't call builder.Populate() - that
      // happens in the AutofacServiceProviderFactory for you.
      services.AddOptions();
    }

    // ConfigureContainer is where you can register things directly
    // with Autofac. This runs after ConfigureServices so the things
    // here will override registrations made in ConfigureServices.
    // Don't build the container; that gets done for you by the factory.
    public void ConfigureContainer(ContainerBuilder builder)
    {
      // Register your own things directly with Autofac here. Don't
      // call builder.Populate(), that happens in AutofacServiceProviderFactory
      // for you.
      // ** 從這裡注入要用的型別 ** //
      //builder.RegisterModule(new MyApplicationModule());
      builder.RegisterType<UseTheForce>().AsSelf().PropertiesAutowired();
      builder.RegisterType<Jedi>().AsSelf().PropertiesAutowired();
      builder.RegisterType<Cars>().As<ICars>().PropertiesAutowired();
      //builder.RegisterType<HomeController>().As<Controller>().PropertiesAutowired();
    }

    // Configure is where you add middleware. This is called after
    // ConfigureContainer. You can use IApplicationBuilder.ApplicationServices
    // here if you need to resolve things from the container.
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      // If, for some reason, you need a reference to the built container, you
      // can use the convenience extension method GetAutofacRoot.
      this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
      /*
      loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();
      app.UseMvc();
      */
      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
/*
ASP.NET Core — Autofac 6.0.0 documentation
https://autofaccn.readthedocs.io/en/latest/integration/aspnetcore.html#asp-net-core-3-0-and-generic-hosting
*/
