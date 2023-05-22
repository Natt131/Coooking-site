using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace RecipeBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:RecipeBookRecipes:ConnectionString"]));

            //services.AddDbContext<AppIdentityContext>(options =>
            //    options.UseSqlServer(
            //        Configuration["Data:RecipeBookIdentity:ConnectionString"]));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppIdentityContext>()
            //    .AddDefaultTokenProviders();

            services.AddTransient<IRecipeRepo, EFRecipeRepo>();
            services.AddTransient<IIngredientRepo, EFIngredientRepo>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseStaticFiles();


          //  if (env.IsDevelopment())
          //  {
                app.UseDeveloperExceptionPage();
         //   }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: null, template: "{controller=Recipe}/{action=Index}/{id?}");
                routes.MapRoute(name: null, template: "{returnUrl}/{controller=Recipe}/{action=Index}/{id?}");
                routes.MapRoute(name: null, template: "{controller=Ingredient}/{action=Index}/{id?}");
                routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
            //IngredientSeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
