using CoreLayer.Results.Abstract;
using DTOLayer.BlogDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using IResult = CoreLayer.Results.Abstract.IResult;

namespace BusinessLayer.Abstrsact
{
    public interface IBlogService
    {
        IDataResult<List<BlogDTOs>> TGetAll();
        IDataResult<List<BlogGetActivDTOs>> TGetActiv();
        IDataResult<BlogDTOs> TGetById(int id);
        IResult TAdd(BlogCreateDTO entity, IFormFile photoUrl, out List<ValidationFailure> errors);
        IResult TUpdate(BlogDTOs entity, IFormFile photoUrl, out List<ValidationFailure> errors);
        IResult TDelete(BlogDTOs entity);
        IResult THardDelete(BlogDTOs entity);



        IDataResult<BlogDTOs> TLastOrDefault();
        IDataResult<List<BlogDTOs>> TLastBlog();
        IDataResult<int> TCount();
    }
}