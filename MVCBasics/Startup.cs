using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;   //using Microsoft.AspNetCore.Http;  ersatts
using Microsoft.Extensions.Configuration;  
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;

namespace MVCBasics
{
    public class Startup
    {

        public IConfiguration Configuration { get; } //lagt till 

        public Startup(IConfiguration configuration) //lagt till
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {



            //För DB SQL Server
            services.AddDbContext<ExDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddSingleton<ICarRepository, MockCarRepository>();// very alike a static - lagt till
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IPeopleService, PeopleService>();





            services.AddMvc(); //denna läggs till för att tala om att vi skall använda MVC


            //För att kunna uppdatera fönster med F5 - lägga till paket 
            //    Tools/NuGet Package Manager/Manage NuGet Package for soloution och installera Microsoft.AspNetCore.Mvc.Razor.ViewCompilation
            //    lägg sedan till denna rad nedan:
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDistributedMemoryCache(); //Tillhör nedan?  //ligger i ramminne server

            services.AddSession(options =>      //läggs till för exempelvis i kombination med Viewbox - här konfig. för att komma ihåg värden från sessionen i 30 minuter
            {                                   //utöver ADD-session så måste en USE-session användas
                                                 //ligger i en cookie-fil på servern - en "sessioncookie" (ej klientcookie)
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });



        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            //Vi lägger här till middelware som går igenom till routing (alltså det som ligger under katalogen "wwwroot")
            //Routern kollar
            //    om regler blockar den så skickad den tillbaka
            //    om de är ok så går den ner till aktuellt middelware-program


            app.UseHttpsRedirection(); //Lagt till

            app.UseStaticFiles();   //"Å DÄR LIGGER DEN JU" - Denna läggs till >> default opens up the wwwroot to be accessed - som nu används som en statisk server
                                    //man öppnar allts upp det an behöver succesivt

            //Denna klippte vi in men den fungerar inte här...  app.UseMvcWithDefaultRoute(); //sätter MVC default. 

            app.UseRouting(); //"här vet jag vad jag skall göra för respons"  
                              //hittar vi filen Wooow - vi kör den och kommer då aldrig ner i Endpoint=defultläge


            app.UseSession();
            //app.UseHttpContextItemsMiddleware();// Core 3 update meesed this one up


            app.UseAuthorization(); //lagt till 



            app.UseEndpoints(endpoints =>
            {
                //special routes before default

                //Lagt till nedan - unika endpoint som ger träff på Controller=Temp/Action=Index - Andra värdet "TempKoll" blir url:en som syns som path
                endpoints.MapControllerRoute(
                    name: "CheckTempInputFromTheUser",  //route-regelns namn
                    pattern: "TempKollen",              //url:en
                    defaults: new { Controller = "Temp", Action = "Index" }); //Controller och Action som anropas (notera bara controllerns PREFIX)


                //Lagt till nedan - unika endpoint som ger träff på Controller=Temp/Action=Index - Andra värdet "TempKoll" blir url:en som syns som path
                endpoints.MapControllerRoute(
                    name: "Kundregister",               //route-regelns namn
                    pattern: "Kundregister",            //url:en
                    defaults: new { Controller = "People", Action = "Index" }); //Controller och Action som anropas (notera bara controllerns PREFIX)


                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");  //denna raden aktiverar htmlsidan vi skall ha katalog HOME och  dess INDEX

            });



        }
    }
}
