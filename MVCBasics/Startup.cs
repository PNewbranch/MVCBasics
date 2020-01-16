using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MVCBasics
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); //denna läggs till för att tala om att vi skall använda MVC
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Vi lägger här till middelware som går igenom till routing (alltså det som ligger under katalogen "wwwroot")
            //Routern kollar
            //    om regler blockar den så skickad den tillbaka
            //    om de är ok så går den ner till aktuellt middelware-program

            //app.UseDefaultFiles(); "JAG SKALL LETA EFTER" - Denna lades till men kommenterades sedan bort då tekniken inte fungerade längre 
            app.UseStaticFiles();   //"Å DÄR LIGGER DEN JU" - Denna läggs till >> default opens up the wwwroot to be accessed - som nu används som en statisk server
                                    //man öppnar allts upp det an behöver succesivt

            //Denna klippte vi in men den fungerar inte här...  app.UseMvcWithDefaultRoute(); //sätter MVC default. 

            app.UseRouting(); //"här vet jag vad jag skall göra för respons"  
                              //hittar vi filen Wooow - vi kör den och kommer då aldrig ner i Endpoint=defultläge


            app.UseEndpoints(endpoints =>
            {
                //special routes before default
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");  //denna raden aktiverar htmlsidan vi skall ha katalog HOME och  dess INDEX

                //denna kod ersätts med rad ovan
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
