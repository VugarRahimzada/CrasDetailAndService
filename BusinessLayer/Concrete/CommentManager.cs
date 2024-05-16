using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.CommentDTO;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public CommentManager(ICommentRepository commentRepository, IBlogRepository blogRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public IResult TAdd(CommentDTOs entity)
        {
            var comment = _mapper.Map<Comment>(entity);
            _commentRepository.Add(comment);
            _blogRepository.IncreesCommentCounta(entity.BlogId);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult TDelete(CommentDTOs entity)
        {
            var comment = _mapper.Map<Comment>(entity);
            _commentRepository.Delete(comment);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }
        public IResult THardDelete(CommentDTOs entity)
        {
            var comment = _mapper.Map<Comment>(entity);
            _commentRepository.HardDelete(comment);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(CommentDTOs entity)
        {
            var comment = _mapper.Map<Comment>(entity);
            _commentRepository.Delete(comment);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IDataResult<List<CommentDTOs>> TGetActiv()
        {
            var comment = _commentRepository.GetActiv();
            var commentdto = _mapper.Map<List<CommentDTOs>>(comment);
            return new SuccessDataResult<List<CommentDTOs>>(commentdto);
        }

        public IDataResult<List<CommentDTOs>> TGetAll()
        {
            var comment = _commentRepository.GetAll();
            var commentdto = _mapper.Map<List<CommentDTOs>>(comment);
            return new SuccessDataResult<List<CommentDTOs>>(commentdto);
        }

        public IDataResult<CommentDTOs> TGetById(int id)
        {
            var comment = _commentRepository.GetById(id);
            var commentdto = _mapper.Map<CommentDTOs>(comment);
            return new SuccessDataResult<CommentDTOs>(commentdto);
        }

        public IDataResult<List<CommentDTOs>> TGetCommentsById(int id)
        {
            var comment = _commentRepository.GetCommentsById(x => x.BlogId == id);
            var commnetdto = _mapper.Map<List<CommentDTOs>>(comment);
            return new SuccessDataResult<List<CommentDTOs>>(commnetdto);
        }

    }
}
