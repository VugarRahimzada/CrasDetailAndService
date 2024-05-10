using AutoMapper;
using BusinessLayer.Abstrsact;
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

        public Result TAdd(TestimonialDTOs entity)
        {
            var testimonial = _mapper.Map<Testimonial>(entity);
            _testimonialRepository.Add(testimonial);
            return new Result("Uğurlu",true);
        }

        public Result TDelete(TestimonialDTOs entity)
        {
            var testimonial = _mapper.Map<Testimonial>(entity);
            _testimonialRepository.Delete(testimonial);
            return new Result("Uğurlu", true);
        }

        public Result THardDelete(TestimonialDTOs entity)
        {
            var testimonial = _mapper.Map<Testimonial>(entity);
            _testimonialRepository.HardDelete(testimonial);
            return new Result("Uğurlu", true);
        }

        public Result TUpdate(TestimonialDTOs entity)
        {
            var testimonial = _mapper.Map<Testimonial>(entity);
            _testimonialRepository.Update(testimonial);
            return new Result("Uğurlu", true);
        }
        public DataResult<List<TestimonialDTOs>> TGetActiv()
        {
            var value = _testimonialRepository.GetActiv();
            var valuedto = _mapper.Map<List<TestimonialDTOs>>(value);

            return new DataResult<List<TestimonialDTOs>>(valuedto, "U]urlu", true);

        }

        public DataResult<List<TestimonialDTOs>> TGetAll()
        {
            var value = _testimonialRepository.GetAll();
            var valuedto = _mapper.Map<List<TestimonialDTOs>>(value);

            return new DataResult<List<TestimonialDTOs>>(valuedto, "U]urlu", true);

        }

        public DataResult<TestimonialDTOs> TGetById(int id)
        {
            var value = _testimonialRepository.GetActiv();
            var valuedto = _mapper.Map<TestimonialDTOs>(value);

            return new DataResult<TestimonialDTOs>(valuedto, "U]urlu", true);

        }

    }
}
