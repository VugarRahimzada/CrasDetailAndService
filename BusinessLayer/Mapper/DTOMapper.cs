using AutoMapper;
using DTOLayer.AboutDTO;
using DTOLayer.AppointmentDTO;
using DTOLayer.BlogDTO;
using DTOLayer.CommentDTO;
using DTOLayer.ContactUs;
using DTOLayer.FAQDTO;
using DTOLayer.OrderDTO;
using DTOLayer.PriceDescriptionDTO;
using DTOLayer.PricingDTO;
using DTOLayer.ServiceDTO;
using DTOLayer.TeamDTO;
using DTOLayer.TestimonialDTO;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CreateMap<CommentDTOs, Comment>().ReverseMap();
            #region ContactUs
            CreateMap<ContactUsDTOs, ContactUs>().ReverseMap(); 
            CreateMap<ContactUsCreateDTOs, ContactUs>().ReverseMap();
            #endregion
            #region FAQ
            CreateMap<FAQDTOs, FAQ>().ReverseMap();
            CreateMap<FAQCreateDTOs, FAQ>().ReverseMap();
            #endregion
            CreateMap<PriceDescriptionDTOs, PriceDescription>().ReverseMap();
            CreateMap<PricingDTOs, Pricing>().ReverseMap();
            CreateMap<ServiceDTOs, Service>().ReverseMap();
            CreateMap<TeamDTOs, Team>().ReverseMap();
            CreateMap<TestimonialDTOs, Testimonial>().ReverseMap();
            CreateMap<OrderDTOs, Order>().ReverseMap();
        }
    }
}
