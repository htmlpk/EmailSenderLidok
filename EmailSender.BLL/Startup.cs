using AutoMapper;
using EmailSender.DAL.Interfaces;
using EmailSender.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EmailSender.BLL
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IRecipientRepository, RecipientRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IRecipientInGroupRepository, RecipientInGroupRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
        }
    }
    
}
