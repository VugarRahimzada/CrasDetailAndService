using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
    public interface ITestimonialService
    {
        IDataResult<List<TestimonialDTOs>> TGetAll();
        IDataResult<List<TestimonialDTOs>> TGetActiv();
        IDataResult<TestimonialDTOs> TGetById(int id);
        IResult TAdd(TestimonialDTOs entity);
        IResult TUpdate(TestimonialDTOs entity);
        IResult TDelete(TestimonialDTOs entity);
        IResult THardDelete(TestimonialDTOs entity);
    }
}
