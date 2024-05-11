using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer;
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
        private readonly IMapper _mapper;

        public CommentManager(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public IResult TAdd(CommentDTOs entity)
        {
            var comment = _mapper.Map<Comment>(entity);
            _commentRepository.Add(comment);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult TDelete(CommentDTOs entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CommentDTOs>> TGetActiv()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CommentDTOs>> TGetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CommentDTOs> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CommentDTOs>> TGetCommentsById(int id)
        {
            var comment = _commentRepository.GetCommentsById(x => x.BlogId == id);
            var commnetdto = _mapper.Map<List<CommentDTOs>>(comment);
            return new SuccessDataResult<List<CommentDTOs>>(commnetdto);
        }

        public IResult THardDelete(CommentDTOs entity)
        {
            throw new NotImplementedException();
        }

        public IResult TUpdate(CommentDTOs entity)
        {
            throw new NotImplementedException();
        }
    }
}
