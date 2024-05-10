using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer;
using EntityLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
    public interface IContactUsService 
    {
        IDataResult<List<ContactUsDTOs>> TGetAll();
        IDataResult<List<ContactUsDTOs>> TGetActiv();
        IDataResult<ContactUsDTOs> TGetById(int id);
        IResult TAdd(ContactUsDTOs entity);
        IResult TUpdate(ContactUsDTOs entity);
        IResult TDelete(ContactUsDTOs entity);
        IResult THardDelete(ContactUsDTOs entity);
    }
}
