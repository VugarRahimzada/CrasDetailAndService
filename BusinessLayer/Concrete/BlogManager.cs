using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Extension;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.BlogDTO;
using EntityLayer.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using CoreResults = CoreLayer.Results.Abstract;
namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IValidator<Blog> _validator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public BlogManager(IBlogRepository blogRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment, IValidator<Blog> validator)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _validator = validator;
        }

        public CoreResults.IResult TAdd(BlogCreateDTO entity, IFormFile photoUrl, out List<ValidationFailure> errors)
        {
            entity.ImageUrl = PictureHelper.UploadImage(photoUrl, _webHostEnvironment.WebRootPath);

            var blog = _mapper.Map<Blog>(entity);
            var validationResult = _validator.Validate(blog);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _blogRepository.Add(blog);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }
        public CoreResults.IResult TDelete(BlogDTOs entity)
        {
            var blog = _mapper.Map<Blog>(entity);
            _blogRepository.Delete(blog);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public CoreResults.IResult THardDelete(BlogDTOs entity)
        {
            var blog = _mapper.Map<Blog>(entity);
            _blogRepository.HardDelete(blog);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }
        public CoreResults.IResult TUpdate(BlogUpdateDTOs entity, IFormFile photoUrl, out List<ValidationFailure> errors)
        {
            var value = _blogRepository.GetById(entity.Id);

            if (photoUrl != null)
            {
                entity.ImageUrl = PictureHelper.UploadImage(photoUrl, _webHostEnvironment.WebRootPath);
            }
            else
            {
                entity.ImageUrl = value.ImageUrl;
            }
            var blog = _mapper.Map<Blog>(entity);
            var validationResult = _validator.Validate(blog);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _blogRepository.Update(blog);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }





        public IDataResult<List<BlogGetActivDTOs>> TGetActiv()
        {
            var blog = _blogRepository.GetActiv();
            var blogdto = _mapper.Map<List<BlogGetActivDTOs>>(blog);
            return new SuccessDataResult<List<BlogGetActivDTOs>>(blogdto, UIMessage.SUCCESS);
        }

        public IDataResult<List<BlogDTOs>> TGetAll()
        {
            var blog = _blogRepository.GetAll();
            var blogdto = _mapper.Map<List<BlogDTOs>>(blog);
            return new SuccessDataResult<List<BlogDTOs>>(blogdto, UIMessage.SUCCESS);
        }

        public IDataResult<BlogDTOs> TGetById(int id)
        {
            var blog = _blogRepository.GetById(id);
            var blogdto = _mapper.Map<BlogDTOs>(blog);
            return new SuccessDataResult<BlogDTOs>(blogdto, UIMessage.SUCCESS);
        }




        public IDataResult<BlogDTOs> TLastOrDefault()
        {
            var blog = _blogRepository.LastOrDefault(x => x.Delete == 0);
            var blogdto = _mapper.Map<BlogDTOs>(blog);

            return new SuccessDataResult<BlogDTOs>(blogdto);
        }

        public IDataResult<List<BlogDTOs>> TLastBlog()
        {
            var blog = _blogRepository.LastBlog(x => x.Delete == 0);
            var blogdto = _mapper.Map<List<BlogDTOs>>(blog);

            return new SuccessDataResult<List<BlogDTOs>>(blogdto);
        }

        public IDataResult<int> TCount()
        {
            var value = _blogRepository.GetActiv().Count();
            return new SuccessDataResult<int>(value);
        }
    }
}