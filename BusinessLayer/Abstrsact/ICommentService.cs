using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer.CommentDTO;
using System.Linq.Expressions;

namespace BusinessLayer.Abstrsact
{
    public interface ICommentService
    {
        IDataResult<List<CommentDTOs>> TGetAll();
        IDataResult<List<CommentActiveDTOs>> TGetActiv();
        IDataResult<CommentDTOs> TGetById(int id);
        IResult TAdd(CommentCreateDTOs entity);
        IResult TUpdate(CommentDTOs entity);
        IResult TDelete(CommentDTOs entity);
        IResult THardDelete(CommentDTOs entity);
        IDataResult<List<CommentDTOs>> TGetCommentsById(int id);
        IDataResult<List<CommentDTOs>> TGetCommentsByIdAdmin(int Id);
    }
}
