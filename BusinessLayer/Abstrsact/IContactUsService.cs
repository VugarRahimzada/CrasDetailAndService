using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer;
using DTOLayer.ContactUs;
using EntityLayer.Models;
using FluentValidation.Results;
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
        IDataResult<List<ContactUsActivDTOs>> TGetActiv();
        IDataResult<ContactUsDTOs> TGetById(int id);
        IResult TAdd(ContactUsCreateDTOs entity, out List<ValidationFailure> errors);
        IResult TUpdate(ContactUsDTOs entity, out List<ValidationFailure> errors);
        IResult TDelete(ContactUsDTOs entity);
        IResult THardDelete(ContactUsDTOs entity);
    }
}
