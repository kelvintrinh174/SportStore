using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportStore.Models;

namespace SportStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        //receive configuration data loaded from appsettings.json
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:SportStoreProducts:ConnectionString"]));

            //registering the Repository service
            //provide access to the database
            services.AddTransient<IProductRepository, EFProductRepository>();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IOrderRepository, EFOrderRepository>();

            services.AddMvc();

            services.AddMemoryCache();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //display details of exceptions
            app.UseDeveloperExceptionPage();
            //add simple message to HTTP responses
            app.UseStatusCodePages();
            //use contents from the wwwroot folder
            app.UseStaticFiles();
            app.UseSession();
            //enable ASP.NET Core MVC 
            app.UseMvc(routes => {
                routes.MapRoute(
                      name: null,
                      template: "{category}/Page{productPage:int}",
                      defaults: new { controller = "Product", action = "List" }
                  );

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });

            //seed database  
            SeedData.EnsurePopulated(app);

        }
       
    }
}
