using CoreLayer.Results.Abstract;
using DTOLayer.BlogDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

using CoreResults = CoreLayer.Results.Abstract;

namespace BusinessLayer.Abstrsact
{
    public interface IBlogService
    {
        IDataResult<List<BlogDTOs>> TGetAll();
        IDataResult<List<BlogGetActivDTOs>> TGetActiv();
        IDataResult<BlogDTOs> TGetById(int id);
        CoreResults.IResult TAdd(BlogCreateDTO entity, IFormFile photoUrl, out List<ValidationFailure> errors);
        CoreResults.IResult TUpdate(BlogDTOs entity, IFormFile photoUrl, out List<ValidationFailure> errors);
        CoreResults.IResult TDelete(BlogDTOs entity);
        CoreResults.IResult THardDelete(BlogDTOs entity);



        IDataResult<BlogDTOs> TLastOrDefault();
        IDataResult<List<BlogDTOs>> TLastBlog();
        IDataResult<int> TCount();
    }
}