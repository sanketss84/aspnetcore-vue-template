using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmailCampaign.Admin.Utility;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace EmailCampaign.Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //add middlewares 
            var builder = services.AddMvc();
            builder.AddMvcOptions(o => { o.Filters.Add(new GlobalExceptionFilter()); });

            //add authentication
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            //add authorization policies
            services.AddAuthorization(options => {
                options.AddPolicy(UserPolicy.SiteUser, policy =>
                {
                    policy.RequireRole(UserPolicy.GenmillsSiteUserGroup,UserPolicy.ExtGenmillsSiteUserGroup);                    
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.EnvironmentName.Equals("Developer") || env.EnvironmentName.Equals("Development"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/PageNotFound";
                    await next();
                }
                else if (context.Response.StatusCode == 403)
                {
                    context.Request.Path = "/Home/ForbiddenError";
                    await next();
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Campaign}/{action=Search}/{id?}");

                routes.MapRoute(
                    name: "CheckSite",
                    template: "checksite.aspx",
                    defaults: new { controller = "Home", action = "CheckSite" });
            });
        }
    }
}
