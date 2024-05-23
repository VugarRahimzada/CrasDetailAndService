using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.CommentDTO;
using EntityLayer.Models;

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

        public IResult TAdd(CommentCreateDTOs entity)
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
            _blogRepository.DecreaseCommentCounta(entity.BlogId);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IDataResult<List<CommentActiveDTOs>> TGetActiv()
        {
            var comment = _commentRepository.GetActiv();
            var commentdto = _mapper.Map<List<CommentActiveDTOs>>(comment);
            return new SuccessDataResult<List<CommentActiveDTOs>>(commentdto);
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
        public IDataResult<List<CommentDTOs>> TGetCommentsByIdAdmin(int id)
        {
            var comment = _commentRepository.GetCommentsByIdAdmin(x => x.BlogId == id);
            var commnetdto = _mapper.Map<List<CommentDTOs>>(comment);
            return new SuccessDataResult<List<CommentDTOs>>(commnetdto);
        }
    }
}