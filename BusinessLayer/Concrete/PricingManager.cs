using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.PricingDTO;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PricingManager : IPricingService
    {
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;

        public PricingManager(IPricingRepository pricingRepository, IMapper mapper)
        {
            _pricingRepository = pricingRepository;
            _mapper = mapper;
        }

        public IResult TAdd(PricingCreateDTOs entity)
        {
            var pricing = _mapper.Map<Pricing>(entity);
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

        public IResult TUpdate(PricingDTOs entity)
        {
            var pricing = _mapper.Map<Pricing>(entity);
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
