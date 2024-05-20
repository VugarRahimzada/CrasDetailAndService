using AutoMapper;
using DTOLayer.AboutDTO;
using DTOLayer.AppointmentDTO;
using DTOLayer.BlogDTO;
using DTOLayer.CommentDTO;
using DTOLayer.ContactUs;
using DTOLayer.EmailSubscriptionDTO;
using DTOLayer.FAQDTO;
using DTOLayer.OrderDTO;
using DTOLayer.PriceDescriptionDTO;
using DTOLayer.PricingDTO;
using DTOLayer.ServiceDTO;
using DTOLayer.TeamDTO;
using DTOLayer.TestimonialDTO;
using EntityLayer.Models;

namespace BusinessLayer.Mapper
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            #region About
            CreateMap<AboutDTOs, About>().ReverseMap();
            CreateMap<AboutGetActivDTOs, About>().ReverseMap();
            CreateMap<AboutCreate, About>().ReverseMap();
            #endregion

            CreateMap<AppointmentDTOs, Appointment>().ReverseMap();

            CreateMap<BlogDTOs, Blog>().ReverseMap();

            #region Comment
            CreateMap<CommentDTOs, Comment>().ReverseMap();
            CreateMap<CommentActiveDTOs, Comment>().ReverseMap();
            CreateMap<CommentCreateDTOs, Comment>().ReverseMap();
            #endregion

            #region ContactUs
            CreateMap<ContactUsDTOs, ContactUs>().ReverseMap(); 
            CreateMap<ContactUsCreateDTOs, ContactUs>().ReverseMap();
            CreateMap<ContactUsActivDTOs, ContactUs>().ReverseMap();
            #endregion

            #region FAQ
            CreateMap<FAQDTOs, FAQ>().ReverseMap();
            CreateMap<FAQCreateDTOs, FAQ>().ReverseMap();
            CreateMap<FAQActivDTOs, FAQ>().ReverseMap();
            #endregion

            CreateMap<OrderDTOs, Order>().ReverseMap();

            #region PriceDescriptionDTOs
            CreateMap<PriceDescriptionDTOs, PriceDescription>().ReverseMap();
            CreateMap<PriceDescriptionActiveDTOs, PriceDescription>().ReverseMap();
            CreateMap<PricingDescriptionCreateDTOs, PriceDescription>().ReverseMap();
            #endregion

            #region Pricing
            CreateMap<PricingDTOs, Pricing>().ReverseMap();
            CreateMap<PricingActivDTOs, Pricing>().ReverseMap();
            CreateMap<PricingCreateDTOs, Pricing>().ReverseMap();

            #endregion

            #region Service
            CreateMap<ServiceDTOs, Service>().ReverseMap();
            CreateMap<ServiceActivDTOs, Service>().ReverseMap();
            CreateMap<ServiceCreateDTOs, Service>().ReverseMap();
            #endregion

            #region Team
            CreateMap<TeamDTOs, Team>().ReverseMap();
            CreateMap<TeamActiveDTOs, Team>().ReverseMap();
            CreateMap<TeamCreateDTOs, Team>().ReverseMap();

            #endregion

            #region Testimonial
            CreateMap<TestimonialDTOs, Testimonial>().ReverseMap();
            CreateMap<TestimonialCreateDTOs, Testimonial>().ReverseMap();
            CreateMap<TestimonialActiveDTOs, Testimonial>().ReverseMap();
            #endregion
            #region EmailSubscription
            CreateMap<EmailSubscriptionDTOs, EmailSubscription>().ReverseMap();
            CreateMap<EmailSubscriptionCreateDTOs, EmailSubscription>().ReverseMap();
            #endregion
        }
    }
}
