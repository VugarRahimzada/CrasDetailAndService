using AutoMapper;
using BusinessLayer.Abstrsact;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer;
using EntityLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsRepository _contactUsrepository;
        private readonly IMapper _mapper;

        public ContactUsManager(IContactUsRepository contactUsrepository, IMapper mapper)
        {
            _contactUsrepository = contactUsrepository;
            _mapper = mapper;
        }

        public Result TAdd(ContactUsDTOs entity)
        {
            var contactus = _mapper.Map<ContactUs>(entity);
            _contactUsrepository.Add(contactus);
            return new Result("Uğurla Əlavə Edildi", true);
        }

        public Result TDelete(ContactUsDTOs entity)
        {
            throw new NotImplementedException();
        }

        public DataResult<List<ContactUsDTOs>> TGetActiv()
        {

            var contacts = _contactUsrepository.GetActiv();

            var contactUsDTOs = _mapper.Map<List<ContactUsDTOs>>(contacts);

            return new DataResult<List<ContactUsDTOs>>(contactUsDTOs, "Uğurlu", true);

        }

        public DataResult<List<ContactUsDTOs>> TGetAll()
        {
            throw new NotImplementedException();
        }

        public DataResult<ContactUsDTOs> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Result THardDelete(ContactUsDTOs entity)
        {
            throw new NotImplementedException();
        }

        public Result TUpdate(ContactUsDTOs entity)
        {
            throw new NotImplementedException();
        }
    }
}



//public void TAdd(ContactUsDTOs entity)
//{
//    var contactUsEntity = _mapper.Map<ContactUs>(entity);
//    _contactUsrepository.Add(contactUsEntity);
//}

//public void TDelete(ContactUsDTOs entity)
//{
//    var contactUsEntity = _mapper.Map<ContactUs>(entity);
//    _contactUsrepository.Delete(contactUsEntity);
//}

//public IEnumerable TGetActiv()
//{
//    var contactus = _contactUsrepository.GetActiv();
//    var contactUsEntity = _mapper.Map<IEnumerable<ContactUsDTOs>>(contactus);

//    return contactUsEntity;
//}

//public IEnumerable TGetAll()
//{
//    var contactus = _contactUsrepository.GetAll();
//    return _mapper.Map<IEnumerable<ContactUsDTOs>>(contactus);
//}

//public ContactUsDTOs TGetById(int id)
//{
//    var contactUsEntity = _contactUsrepository.GetById(id);
//    return _mapper.Map<ContactUsDTOs>(contactUsEntity);
//}

//public void THardDelete(ContactUsDTOs entity)
//{
//    var contactUsEntity = _mapper.Map<ContactUs>(entity);
//    _contactUsrepository.HardDelete(contactUsEntity);
//}

//public void TUpdate(ContactUsDTOs entity)
//{
//    var contactUsEntity = _mapper.Map<ContactUs>(entity);
//    _contactUsrepository.Update(contactUsEntity);
//}