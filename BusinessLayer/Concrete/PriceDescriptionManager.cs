using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using DTOLayer.PriceDescriptionDTO;
using EntityLayer.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PriceDescriptionManager : IPriceDescriptionsService
    {

        private readonly IPriceDescriptionRepository _priceDescriptionRepository;
        private readonly IValidator<PriceDescription> _validator;
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;

        public PriceDescriptionManager(IPriceDescriptionRepository priceDescriptionRepository, IPricingRepository pricingRepository, IMapper mapper, IValidator<PriceDescription> validator)
        {
            _priceDescriptionRepository = priceDescriptionRepository;
            _pricingRepository = pricingRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public IResult TAdd(PricingDescriptionCreateDTOs entity, out List<ValidationFailure> errors)
        {
            var pdes = _mapper.Map<PriceDescription>(entity);
            var validationResult = _validator.Validate(pdes);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _priceDescriptionRepository.Add(pdes);
            return new SuccessResult(UIMessage.ADD_SUCCESS);

        }

        public IResult TDelete(PriceDescriptionDTOs entity)
        {
            var pdes = _mapper.Map<PriceDescription>(entity);
            _priceDescriptionRepository.Delete(pdes);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IDataResult<List<PriceDescriptionActiveDTOs>> TGetActiv()
        { 
            var pdes = _priceDescriptionRepository.GetActiv();
            var pdesdtos = _mapper.Map<List<PriceDescriptionActiveDTOs>>(pdes);

            return new SuccessDataResult<List<PriceDescriptionActiveDTOs>>(pdesdtos);
        }

        public IDataResult<List<PriceDescriptionDTOs>> TGetOrderWithPricingCategory()
        {
            var pdes = _priceDescriptionRepository.GetOrderWithPricingCategory();
            var pdesdtos = _mapper.Map<List<PriceDescriptionDTOs>>(pdes);

            return new SuccessDataResult<List<PriceDescriptionDTOs>>(pdesdtos);
        }

        public IDataResult<PriceDescriptionDTOs> TGetById(int id)
        {
            var pdes = _priceDescriptionRepository.GetById(id);
            var pdesdtos = _mapper.Map<PriceDescriptionDTOs>(pdes);

            return new SuccessDataResult<PriceDescriptionDTOs>(pdesdtos);
        }

        public IResult THardDelete(PriceDescriptionDTOs entity)
        {
            var pdes = _mapper.Map<PriceDescription>(entity);
            _priceDescriptionRepository.HardDelete(pdes);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(PriceDescriptionDTOs entity, out List<ValidationFailure> errors)
        {
            var pdes = _mapper.Map<PriceDescription>(entity);
            var validationResult = _validator.Validate(pdes);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }

            _priceDescriptionRepository.Update(pdes);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }
        public IDataResult<List<PriceDescriptionActiveDTOs>> TGetActivByPricingId(int pricingId)
        {
            var pdes = _priceDescriptionRepository.GetActiv().Where(p => p.PricingId == pricingId).ToList();
            var pdesdtos = _mapper.Map<List<PriceDescriptionActiveDTOs>>(pdes);

            return new SuccessDataResult<List<PriceDescriptionActiveDTOs>>(pdesdtos);
        }

    }
}
