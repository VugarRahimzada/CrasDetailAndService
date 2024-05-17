using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Extension;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.BlogDTO;
using EntityLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public BlogManager(IBlogRepository blogRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public CoreLayer.Results.Abstract.IResult TAdd(BlogDTOs entity,IFormFile photoUrl)
        {
            entity.ImageUrl= PictureHelper.UploadImage(photoUrl, _webHostEnvironment.WebRootPath);
            var blog = _mapper.Map<Blog>(entity);
            _blogRepository.Add(blog);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }
        public CoreLayer.Results.Abstract.IResult TDelete(BlogDTOs entity)
        {
            var blog = _mapper.Map<Blog>(entity);
            _blogRepository.Delete(blog);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public CoreLayer.Results.Abstract.IResult THardDelete(BlogDTOs entity)
        {
            var blog = _mapper.Map<Blog>(entity);
            _blogRepository.HardDelete(blog);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }
        public CoreLayer.Results.Abstract.IResult TUpdate(BlogDTOs entity,IFormFile photoUrl)
        {
            var value = _blogRepository.GetById(entity.Id);

            if (photoUrl !=null)
            {
                entity.ImageUrl = PictureHelper.UploadImage(photoUrl, _webHostEnvironment.WebRootPath);
            }
            else
            {
                entity.ImageUrl = value.ImageUrl;
            }
            var blog = _mapper.Map<Blog>(entity);
            _blogRepository.Update(blog);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }

        public IDataResult<List<BlogDTOs>> TGetActiv()
        {
            var blog = _blogRepository.GetActiv();
            var blogdto = _mapper.Map<List<BlogDTOs>>(blog);
            return new SuccessDataResult<List<BlogDTOs>>(blogdto,UIMessage.SUCCESS);
        }

        public IDataResult<List<BlogDTOs>> TGetAll()
        {
            var blog = _blogRepository.GetAll();
            var blogdto = _mapper.Map<List<BlogDTOs>>(blog);
            return new SuccessDataResult<List<BlogDTOs>>(blogdto,UIMessage.SUCCESS);
        }

        public IDataResult<BlogDTOs> TGetById(int id)
        {
            var blog = _blogRepository.GetById(id);
            var blogdto = _mapper.Map<BlogDTOs>(blog);
            return new SuccessDataResult<BlogDTOs>(blogdto,UIMessage.SUCCESS);
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
    }
}
