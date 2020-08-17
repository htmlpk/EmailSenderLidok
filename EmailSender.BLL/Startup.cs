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
            services.AddTransient<IRecipientRepository, RecipientRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IRecipientInGroupRepository, RecipientInGroupRepository>();
            services.AddTransient<ITemplateRepository, TemplateRepository>();
            services.AddTransient<IEmailHandlerRepository, EmailHandlerRepository>();
        }
    }
    
}
