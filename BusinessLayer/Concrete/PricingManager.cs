using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DocumentFormat.OpenXml.Wordprocessing;
using DTOLayer.PricingDTO;
using EntityLayer.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace BusinessLayer.Concrete
{
    public class PricingManager : IPricingService
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IValidator<Pricing> _validator;
        private readonly IMapper _mapper;

        public PricingManager(IPricingRepository pricingRepository, IMapper mapper, IValidator<Pricing> validator)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public IResult TAdd(PricingCreateDTOs entity, out List<ValidationFailure> errors)
        {

            var pricing = _mapper.Map<Pricing>(entity);
            var validationResult = _validator.Validate(pricing);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _pricingRepository.Add(pricing);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult TDelete(PricingDTOs entity)
        {
            var pricing = _mapper.Map<Pricing>(entity);
            _pricingRepository.Delete(pricing);

            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }
        public IResult THardDelete(PricingDTOs entity)
        {
            var pricing = _mapper.Map<Pricing>(entity);
            _pricingRepository.HardDelete(pricing);

            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(PricingDTOs entity, out List<ValidationFailure> errors)
        {
            var pricing = _mapper.Map<Pricing>(entity);
            var validationResult = _validator.Validate(pricing);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _pricingRepository.Update(pricing);

            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }
        public IDataResult<List<PricingActivDTOs>> TGetActiv()
        {
            var pricing = _pricingRepository.GetActiv();
            var pricingdtos = _mapper.Map<List<PricingActivDTOs>>(pricing);

            return new SuccessDataResult<List<PricingActivDTOs>>(pricingdtos);

        }

        public IDataResult<List<PricingDTOs>> TGetAll()
        {
            var pricing = _pricingRepository.GetAll();
            var pricingdtos = _mapper.Map<List<PricingDTOs>>(pricing);

            return new SuccessDataResult<List<PricingDTOs>>(pricingdtos);
        }

        public IDataResult<PricingDTOs> TGetById(int id)
        {
            var pricing = _pricingRepository.GetById(id);
            var pricingdtos = _mapper.Map<PricingDTOs>(pricing);

            return new SuccessDataResult<PricingDTOs>(pricingdtos);
        }


    }
}
