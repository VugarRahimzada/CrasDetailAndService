using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Extension;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.TestimonialDTO;
using EntityLayer.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using IResult = CoreLayer.Results.Abstract;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IValidator<Testimonial> _validator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public TestimonialManager(ITestimonialRepository testimonialRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment, IValidator<Testimonial> validator)
        {
            _testimonialRepository = testimonialRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _validator = validator;
        }

        public IResult.IResult TAdd(TestimonialCreateDTOs entity, IFormFile photoUrl,out List<ValidationFailure> errors)
        {
            entity.ImageUrl = PictureHelper.UploadImage(photoUrl, _webHostEnvironment.WebRootPath);
            var testimonial = _mapper.Map<Testimonial>(entity);
            var validationResult = _validator.Validate(testimonial);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _testimonialRepository.Add(testimonial);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult.IResult TDelete(TestimonialDTOs entity)
        {
            var testimonial = _mapper.Map<Testimonial>(entity);
            _testimonialRepository.Delete(testimonial);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult.IResult THardDelete(TestimonialDTOs entity)
        {
            var testimonial = _mapper.Map<Testimonial>(entity);
            _testimonialRepository.HardDelete(testimonial);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult.IResult TUpdate(TestimonialUpdateDTOs entity, IFormFile photoUrl, out List<ValidationFailure> errors)
        {
            var existData = TGetById(entity.Id).Data;
            if (photoUrl != null)
            {
                entity.ImageUrl = PictureHelper.UploadImage(photoUrl, _webHostEnvironment.WebRootPath);
            }
            else
            {
                entity.ImageUrl = existData.ImageUrl;
            }


            var testimonial = _mapper.Map<Testimonial>(entity);
            var validationResult = _validator.Validate(testimonial);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _testimonialRepository.Update(testimonial);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }
        public IDataResult<List<TestimonialActiveDTOs>> TGetActiv()
        {
            var value = _testimonialRepository.GetActiv();
            var valuedto = _mapper.Map<List<TestimonialActiveDTOs>>(value);

            return new SuccessDataResult<List<TestimonialActiveDTOs>>(valuedto);

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
