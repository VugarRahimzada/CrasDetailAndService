using CoreLayer.Results.Abstract;
using DTOLayer.ServiceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
    public interface IServiceService
    {
        IDataResult<List<ServiceDTOs>> TGetAll();
        IDataResult<List<ServiceDTOs>> TGetActiv();
        IDataResult<ServiceDTOs> TGetById(int id);
        IResult TAdd(ServiceDTOs entity);
        IResult TUpdate(ServiceDTOs entity);
        IResult TDelete(ServiceDTOs entity);
        IResult THardDelete(ServiceDTOs entity);
    }
}
