using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        protected readonly ITestimonialRepository _testimonialRepository;
        protected readonly IMapper _mapper;

        public TestimonialManager(ITestimonialRepository testimonialRepository, IMapper mapper)
        {
            _testimonialRepository = testimonialRepository;
            _mapper = mapper;
        }

        public IResult TAdd(TestimonialDTOs entity)
        {
            var testimonial = _mapper.Map<Testimonial>(entity);
            _testimonialRepository.Add(testimonial);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult TDelete(TestimonialDTOs entity)
        {
            var testimonial = _mapper.Map<Testimonial>(entity);
            _testimonialRepository.Delete(testimonial);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult THardDelete(TestimonialDTOs entity)
        {
            var testimonial = _mapper.Map<Testimonial>(entity);
            _testimonialRepository.HardDelete(testimonial);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(TestimonialDTOs entity)
        {
            var testimonial = _mapper.Map<Testimonial>(entity);
            _testimonialRepository.Update(testimonial);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }
        public IDataResult<List<TestimonialDTOs>> TGetActiv()
        {
            var value = _testimonialRepository.GetActiv();
            var valuedto = _mapper.Map<List<TestimonialDTOs>>(value);

            return new SuccessDataResult<List<TestimonialDTOs>>(valuedto);

        }

        public IDataResult<List<TestimonialDTOs>> TGetAll()
        {
            var value = _testimonialRepository.GetAll();
            var valuedto = _mapper.Map<List<TestimonialDTOs>>(value);

            return new SuccessDataResult<List<TestimonialDTOs>>(valuedto);

        }

        public IDataResult<TestimonialDTOs> TGetById(int id)
        {
            var value = _testimonialRepository.GetById(id);
            var valuedto = _mapper.Map<TestimonialDTOs>(value);

            return new SuccessDataResult<TestimonialDTOs>(valuedto);

        }

    }
}
