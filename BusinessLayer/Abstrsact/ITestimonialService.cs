using CoreLayer.Results.Abstract;
using DTOLayer.TestimonialDTO;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Abstrsact
{
    public interface ITestimonialService
    {
        IDataResult<List<TestimonialDTOs>> TGetAll();
        IDataResult<List<TestimonialActiveDTOs>> TGetActiv();
        IDataResult<TestimonialDTOs> TGetById(int id);
        CoreLayer.Results.Abstract.IResult TAdd(TestimonialCreateDTOs entity, IFormFile photoUrl);
        CoreLayer.Results.Abstract.IResult TUpdate(TestimonialDTOs entity, IFormFile photoUrl);
        CoreLayer.Results.Abstract.IResult TDelete(TestimonialDTOs entity);
        CoreLayer.Results.Abstract.IResult THardDelete(TestimonialDTOs entity);
    }
}
