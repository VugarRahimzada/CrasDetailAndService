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
        DataResult<List<ContactUsDTOs>> TGetAll();
        DataResult<List<ContactUsDTOs>> TGetActiv();
        DataResult<ContactUsDTOs> TGetById(int id);
        Result TAdd(ContactUsDTOs entity);
        Result TUpdate(ContactUsDTOs entity);
        Result TDelete(ContactUsDTOs entity);
        Result THardDelete(ContactUsDTOs entity);
    }
}
