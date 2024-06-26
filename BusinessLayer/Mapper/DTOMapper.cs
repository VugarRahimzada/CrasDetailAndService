﻿using AutoMapper;
using DTOLayer.AboutDTO;
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
            CreateMap<AboutCreateDTOs, About>().ReverseMap();
            CreateMap<AboutUpdateDTOs, About>().ReverseMap();
            #endregion

            #region Blog

            CreateMap<BlogDTOs, Blog>().ReverseMap();
            CreateMap<BlogCreateDTO, Blog>().ReverseMap();
            CreateMap<BlogGetActivDTOs, Blog>().ReverseMap();
            CreateMap<BlogUpdateDTOs, Blog>().ReverseMap();

            #endregion

            #region Comment
            CreateMap<CommentDTOs, Comment>().ReverseMap();
            CreateMap<CommentActiveDTOs, Comment>().ReverseMap();
            CreateMap<CommentCreateDTOs, Comment>().ReverseMap();
            #endregion

            #region ContactUs
            CreateMap<ContactUsDTOs, ContactUs>().ReverseMap(); 
            CreateMap<ContactUsCreateDTOs, ContactUs>().ReverseMap();
            CreateMap<ContactUsActivDTOs, ContactUs>().ReverseMap();
            CreateMap<ContactUsUpdateDTOs, ContactUs>().ReverseMap();
            #endregion

            #region FAQ
            CreateMap<FAQDTOs, FAQ>().ReverseMap();
            CreateMap<FAQCreateDTOs, FAQ>().ReverseMap();
            CreateMap<FAQActivDTOs, FAQ>().ReverseMap();
            CreateMap<FAQUpdateDTOs, FAQ>().ReverseMap();
            #endregion

            #region Order

            CreateMap<OrderDTOs, Order>().ReverseMap();
            CreateMap<OrderUpdateDTOs, Order>().ReverseMap();
            CreateMap<OrderCreateDTOs, Order>().ReverseMap();

            #endregion

            #region PriceDescriptionDTOs
            CreateMap<PriceDescriptionDTOs, PriceDescription>().ReverseMap();
            CreateMap<PriceDescriptionActiveDTOs, PriceDescription>().ReverseMap();
            CreateMap<PricingDescriptionCreateDTOs, PriceDescription>().ReverseMap();
            CreateMap<PricingDescriptionUpdateDTOs, PriceDescription>().ReverseMap();
            #endregion

            #region Pricing
            CreateMap<PricingDTOs, Pricing>().ReverseMap();
            CreateMap<PricingActivDTOs, Pricing>().ReverseMap();
            CreateMap<PricingCreateDTOs, Pricing>().ReverseMap();
            CreateMap<PricingUpdateDTOs, Pricing>().ReverseMap();

            #endregion

            #region Service
            CreateMap<ServiceDTOs, Service>().ReverseMap();
            CreateMap<ServiceActivDTOs, Service>().ReverseMap();
            CreateMap<ServiceCreateDTOs, Service>().ReverseMap();
            CreateMap<ServiceUpdateDTOs, Service>().ReverseMap();
            #endregion

            #region Team
            CreateMap<TeamDTOs, Team>().ReverseMap();
            CreateMap<TeamActiveDTOs, Team>().ReverseMap();
            CreateMap<TeamCreateDTOs, Team>().ReverseMap();
            CreateMap<TeamUpdateDTOs, Team>().ReverseMap();

            #endregion

            #region Testimonial
            CreateMap<TestimonialDTOs, Testimonial>().ReverseMap();
            CreateMap<TestimonialCreateDTOs, Testimonial>().ReverseMap();
            CreateMap<TestimonialActiveDTOs, Testimonial>().ReverseMap();
            CreateMap<TestimonialUpdateDTOs, Testimonial>().ReverseMap();
            #endregion

            #region EmailSubscription
            CreateMap<EmailSubscriptionDTOs, EmailSubscription>().ReverseMap();
            CreateMap<EmailSubscriptionCreateDTOs, EmailSubscription>().ReverseMap();
            CreateMap<EmailSubscriptionCreateDTOs, EmailSubscription>().ReverseMap();
            #endregion
        }
    }
}
