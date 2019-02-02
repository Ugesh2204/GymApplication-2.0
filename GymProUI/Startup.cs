using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPBLL;
using GPBOL;
using GPDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymProUI
{
    public class Startup
    {

        IConfiguration Configuration { get; }

        public Startup(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //aLL Interface and object should be added here
            //BLL services
            services.AddTransient<IGoalBs, GoalBs>();
            services.AddTransient<IGPWorkoutBs, GPWorkoutBs>();

            //DAL services
            services.AddTransient<IGoalDb, GoalDb>();
            services.AddTransient<IGPWorkoutDb, GPWorkoutDb>();

            services.AddDbContext<GPDbContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("GPConStr")));


            services.AddIdentity<GPUser, IdentityRole>().
                AddEntityFrameworkStores<GPDbContext>().
                AddDefaultTokenProviders();


            var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();

            services.AddMvc(x =>x.Filters.Add(new AuthorizeFilter(policy)));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            //app.UseAuthentication();
            app.UseMvc(routes => //Configure
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Goals}/{action=Index}/{id?}");
            });
        }
    }
}
