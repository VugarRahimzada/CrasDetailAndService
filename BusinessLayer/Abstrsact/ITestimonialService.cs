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
        DataResult<List<TestimonialDTOs>> TGetAll();
        DataResult<List<TestimonialDTOs>> TGetActiv();
        DataResult<TestimonialDTOs> TGetById(int id);
        Result TAdd(TestimonialDTOs entity);
        Result TUpdate(TestimonialDTOs entity);
        Result TDelete(TestimonialDTOs entity);
        Result THardDelete(TestimonialDTOs entity);
    }
}
