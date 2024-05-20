using CoreLayer.Results.Abstract;
using DTOLayer.BlogDTO;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Abstrsact
{
    public interface IBlogService
    {
        IDataResult<List<BlogDTOs>> TGetAll();
        IDataResult<List<BlogDTOs>> TGetActiv();
        IDataResult<BlogDTOs> TGetById(int id);
        IDataResult<BlogDTOs> TLastOrDefault();
        IDataResult<List<BlogDTOs>> TLastBlog();
        CoreLayer.Results.Abstract.IResult TAdd(BlogDTOs entity, IFormFile photoUrl);
        CoreLayer.Results.Abstract.IResult TUpdate(BlogDTOs entity, IFormFile photoUrl);
        CoreLayer.Results.Abstract.IResult TDelete(BlogDTOs entity);
        CoreLayer.Results.Abstract.IResult THardDelete(BlogDTOs entity);
        IDataResult<int> TCount();
    }
}
