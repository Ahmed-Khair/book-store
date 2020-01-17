
using book_store.Models;
using book_store.Models.repositories;
using book_store.repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;


namespace book_store
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            //    special auther repositories

            services.AddScoped<repositoriesInterface<Auther>, AutherDBrepository>();

            // special book repositories
            services.AddScoped<repositoriesInterface<Book>, BookDBrepository>();

            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddControllersWithViews();
            
            services.AddDbContextPool<Dbcontxt>(options => options.UseSqlServer(configuration.GetConnectionString("con")));


            services.AddMvc().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();تغيير الصفحه اول ما البرنامج يفتح
             
            app.UseMvc(route =>
            {
                route.MapRoute("default", "{controller=Book}/{action=Index}");
            });



        }
    }
}
