using BusinessLayer.Abstrsact;
using BusinessLayer.Concrete;
using BusinessLayer.Validation.FluentValidations;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Models;
using FluentValidation;

namespace FinalProjectVR.Extensions
{
    public static class ServiceHandlerExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {

             services.AddScoped<IValidator<About>, AboutValidation>();
             services.AddScoped<IValidator<Pricing>, PriceValidation>();
             services.AddScoped<IValidator<Blog>, BlogValidation>();




             services.AddScoped<IContactUsService, ContactUsManager>();
             services.AddScoped<IContactUsRepository, ContactUsRepository>();
             services.AddScoped<IOrderService, OrderManager>();
             services.AddScoped<IOrderRepository, OrderRepository>();
             services.AddScoped<IPricingService, PricingManager>();
             services.AddScoped<IPricingRepository, PricingRepository>();
             services.AddScoped<IFAQRepository, FAQRepository>();
             services.AddScoped<IFAQService, FAQManager>();
             services.AddScoped<IPriceDescriptionsService, PriceDescriptionManager>();
             services.AddScoped<IPriceDescriptionRepository, PriceDescriptionRepository>();
             services.AddScoped<ITeamService, TeamManager>();
             services.AddScoped<ITeamRepository, TeamRepository>();
             services.AddScoped<IAboutService, AboutManager>();
             services.AddScoped<IAboutRepository, AboutRepository>();
             services.AddScoped<ITestimonialService, TestimonialManager>();
             services.AddScoped<ITestimonialRepository, TestimonialRepository>();
             services.AddScoped<IServiceService, ServiceManager>();
             services.AddScoped<IServiceRepository, ServiceRepository>();
             services.AddScoped<IBlogService,BlogManager>();
             services.AddScoped<IBlogRepository, BlogRepository>();
             services.AddScoped<ICommentService, CommentManager>();
             services.AddScoped<ICommentRepository, CommentRepository>();
             services.AddScoped<IEmailSubscriptionRepository, EmailSubscriptionRepository>();
             services.AddScoped<IEmailSubscriptionService, EmailSubscriptionManager>();
        }
    }
}
