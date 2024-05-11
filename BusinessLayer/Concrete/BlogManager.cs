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
    public class BlogManager : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogManager(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public IResult TAdd(BlogDTOs entity)
        {
            var blog = _mapper.Map<Blog>(entity);
            _blogRepository.Add(blog);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }
        public IResult TDelete(BlogDTOs entity)
        {
            var blog = _mapper.Map<Blog>(entity);
            _blogRepository.Delete(blog);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult THardDelete(BlogDTOs entity)
        {
            var blog = _mapper.Map<Blog>(entity);
            _blogRepository.HardDelete(blog);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }
        public IResult TUpdate(BlogDTOs entity)
        {
            var blog = _mapper.Map<Blog>(entity);
            _blogRepository.Add(blog);
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
            var blog = _blogRepository.GetActiv();
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
    }
}
