using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer;
using DTOLayer.ContactUs;
using EntityLayer.Models;
using FluentValidation;
using FluentValidation.Results;
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
        private readonly IValidator<ContactUs> _validator;
        private readonly IMapper _mapper;

        public ContactUsManager(IContactUsRepository contactUsrepository, IMapper mapper, IValidator<ContactUs> validator)
        {
            _contactUsrepository = contactUsrepository;
            _mapper = mapper;
            _validator = validator;
        }

        public IResult TAdd(ContactUsCreateDTOs entity, out List<ValidationFailure> errors)
        {
            var contactus = _mapper.Map<ContactUs>(entity);
            var validationResult = _validator.Validate(contactus);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _contactUsrepository.Add(contactus);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult TDelete(ContactUsDTOs entity)
        {
            var contactus = _mapper.Map<ContactUs>(entity);
            _contactUsrepository.Delete(contactus);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult THardDelete(ContactUsDTOs entity)
        {
            var contactus = _mapper.Map<ContactUs>(entity);
            _contactUsrepository.HardDelete(contactus);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(ContactUsDTOs entity, out List<ValidationFailure> errors)
        {
            var contactus = _mapper.Map<ContactUs>(entity);
            var validationResult = _validator.Validate(contactus);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _contactUsrepository.Update(contactus);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }

        public IDataResult<List<ContactUsActivDTOs>> TGetActiv()
        {

            var contacts = _contactUsrepository.GetActiv();

            var contactUsDTOs = _mapper.Map<List<ContactUsActivDTOs>>(contacts);

            return new SuccessDataResult<List<ContactUsActivDTOs>>(contactUsDTOs);

        }

        public IDataResult<List<ContactUsDTOs>> TGetAll()
        {
            var contacts = _contactUsrepository.GetAll();

            var contactUsDTOs = _mapper.Map<List<ContactUsDTOs>>(contacts);

            return new SuccessDataResult<List<ContactUsDTOs>>(contactUsDTOs);
        }

        public IDataResult<ContactUsDTOs> TGetById(int id)
        {
            var contacts = _contactUsrepository.GetById(id);

            var contactUsDTOs = _mapper.Map<ContactUsDTOs>(contacts);

            return new SuccessDataResult<ContactUsDTOs>(contactUsDTOs);
        }

    }
}

