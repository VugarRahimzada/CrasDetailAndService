using AutoMapper;
using BusinessLayer.Abstrsact;
using CoreLayer.Results.Abstract;
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

        public IResult TAdd(ContactUsDTOs entity)
        {
            var contactus = _mapper.Map<ContactUs>(entity);
            _contactUsrepository.Add(contactus);
            return new SuccessResult("Uğurla Əlavə Edildi");
        }

        public IResult TDelete(ContactUsDTOs entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ContactUsDTOs>> TGetActiv()
        {

            var contacts = _contactUsrepository.GetActiv();

            var contactUsDTOs = _mapper.Map<List<ContactUsDTOs>>(contacts);

            return new SuccessDataResult<List<ContactUsDTOs>>(contactUsDTOs, "Uğurlu");

        }

        public IDataResult<List<ContactUsDTOs>> TGetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<ContactUsDTOs> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult THardDelete(ContactUsDTOs entity)
        {
            throw new NotImplementedException();
        }

        public IResult TUpdate(ContactUsDTOs entity)
        {
            throw new NotImplementedException();
        }
    }
}

