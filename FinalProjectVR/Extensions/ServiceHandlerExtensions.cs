using BusinessLayer.Abstrsact;
using BusinessLayer.Concrete;
using BusinessLayer.Validation.FluentValidations;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.TestimonialDTO;
using EntityLayer.Models;
using FinalProjectVR.ViewComponents;
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
             services.AddScoped<IValidator<FAQ>, FAQValidation>();
             services.AddScoped<IValidator<Team>, TeamValidation>(); 
             services.AddScoped<IValidator<Comment>, CommentValidation>();
             services.AddScoped<IValidator<ContactUs>, ContactUsValidation>();
             services.AddScoped<IValidator<EmailSubscription>, EmailSubscriptionValidation>();
             services.AddScoped<IValidator<Service>, ServiceValidation>();
             services.AddScoped<IValidator<Order>, OrderValidation>(); 
             services.AddScoped<IValidator<PriceDescription>, PriceDescriptionValidation>(); 



                        
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
