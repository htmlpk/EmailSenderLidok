using EmailSender.BLL.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using EmailSender.BLL.Services;
using System.Threading.Tasks;
using EmailSender.EmailHandler.Interface;
using EmailSender.EmailHandler;

namespace EmailSenderLidok
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
            
            services.AddControllersWithViews();

            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Email sender API", Version = "V1" }));
            EmailSender.BLL.Startup.ConfigureServices(services);
            EmailSender.DAL.Startup.ConfigureServices(services, Configuration);
            ConfigureScopedServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Email sender API "));
        }

        public void ConfigureScopedServices(IServiceCollection services)
        {
            services.AddScoped<IRecipientService, RecipientService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITemplateService, TemplateService>();
            //services.AddHostedService<TimedHostedService>();
            services.AddHostedService<ConsumeScopedServiceHostedService>();
            services.AddScoped<EmailSender.EmailHandler.IScopedProcessingService, ScopedProcessingService>();
        }
    }
}
