using AutoMapper;
using DTOLayer;
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
            CreateMap<AboutDTOs, About>().ReverseMap();
            CreateMap<AppointmentDTOs, Appointment>().ReverseMap();
            CreateMap<BlogDTOs, Blog>().ReverseMap();
            CreateMap<CommentDTOs, Comment>().ReverseMap();
            CreateMap<ContactUsDTOs, ContactUs>().ReverseMap(); 
            CreateMap<FAQDTOs, FAQ>().ReverseMap();
            CreateMap<PriceDescriptionDTOs, PriceDescription>().ReverseMap();
            CreateMap<PricingDTOs, Pricing>().ReverseMap();
            CreateMap<ServiceDTOs, Service>().ReverseMap();
            CreateMap<TeamDTOs, Team>().ReverseMap();
            CreateMap<TestimonialDTOs, Testimonial>().ReverseMap();
            CreateMap<OrderDTOs, Order>().ReverseMap();
        }
    }
}
