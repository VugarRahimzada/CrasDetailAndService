using CoreLayer.Results.Abstract;
using DTOLayer.CommentDTO;

namespace BusinessLayer.Abstrsact
{
    public interface ICommentService
    {
        IDataResult<List<CommentDTOs>> TGetAll();
        IDataResult<List<CommentDTOs>> TGetActiv();
        IDataResult<CommentDTOs> TGetById(int id);
        IResult TAdd(CommentDTOs entity);
        IResult TUpdate(CommentDTOs entity);
        IResult TDelete(CommentDTOs entity);
        IResult THardDelete(CommentDTOs entity);
        IDataResult<List<CommentDTOs>> TGetCommentsById(int id);
    }
}
