using CoreLayer.Results.Abstract;
using DTOLayer.TestimonialDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using IResult = CoreLayer.Results.Abstract;

namespace BusinessLayer.Abstrsact
{
    public interface ITestimonialService
    {
        IDataResult<List<TestimonialDTOs>> TGetAll();
        IDataResult<List<TestimonialActiveDTOs>> TGetActiv();
        IDataResult<TestimonialDTOs> TGetById(int id);
        IResult.IResult TAdd(TestimonialCreateDTOs entity, IFormFile photoUrl, out List<ValidationFailure> errors);
        IResult.IResult TUpdate(TestimonialDTOs entity, IFormFile photoUrl, out List<ValidationFailure> errors);
        IResult.IResult TDelete(TestimonialDTOs entity);
        IResult.IResult THardDelete(TestimonialDTOs entity);
    }
}
