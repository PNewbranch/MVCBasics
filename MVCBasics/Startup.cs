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
            services.AddMvc(); //denna l�ggs till f�r att tala om att vi skall anv�nda MVC
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Vi l�gger h�r till middelware som g�r igenom till routing (allts� det som ligger under katalogen "wwwroot")
            //Routern kollar
            //    om regler blockar den s� skickad den tillbaka
            //    om de �r ok s� g�r den ner till aktuellt middelware-program

            //app.UseDefaultFiles(); "JAG SKALL LETA EFTER" - Denna lades till men kommenterades sedan bort d� tekniken inte fungerade l�ngre 
            app.UseStaticFiles();   //"� D�R LIGGER DEN JU" - Denna l�ggs till >> default opens up the wwwroot to be accessed - som nu anv�nds som en statisk server
                                    //man �ppnar allts upp det an beh�ver succesivt

            //Denna klippte vi in men den fungerar inte h�r...  app.UseMvcWithDefaultRoute(); //s�tter MVC default. 

            app.UseRouting(); //"h�r vet jag vad jag skall g�ra f�r respons"  
                              //hittar vi filen Wooow - vi k�r den och kommer d� aldrig ner i Endpoint=defultl�ge


            app.UseEndpoints(endpoints =>
            {
                //special routes before default
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");  //denna raden aktiverar htmlsidan vi skall ha katalog HOME och  dess INDEX

                //denna kod ers�tts med rad ovan
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
