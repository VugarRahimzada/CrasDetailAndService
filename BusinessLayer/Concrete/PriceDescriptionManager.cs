using AutoMapper;
using BusinessLayer.Abstrsact;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer;
using EntityLayer.Models;
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
        private readonly IPricingRepository _pricingRepository;
        private readonly IMapper _mapper;

        public PriceDescriptionManager(IPriceDescriptionRepository priceDescriptionRepository, IPricingRepository pricingRepository , IMapper mapper)
        {
            _priceDescriptionRepository = priceDescriptionRepository;
            _pricingRepository = pricingRepository;
            _mapper = mapper;
        }

        public Result TAdd(PriceDescriptionDTOs entity)
        {
            var pdes = _mapper.Map<PriceDescription>(entity);
             _priceDescriptionRepository.Add(pdes);
            return new Result("Uğurla Əlavə Edildi", true);

        }

        public Result TDelete(PriceDescriptionDTOs entity)
        {
            var pdes = _mapper.Map<PriceDescription>(entity);
            _priceDescriptionRepository.Delete(pdes);
            return new Result("Uğurla Əlavə Edildi", true);
        }

        public DataResult<List<PriceDescriptionDTOs>> TGetActiv()
        { 
            var pdes = _priceDescriptionRepository.GetActiv();
            var pdesdtos = _mapper.Map<List<PriceDescriptionDTOs>>(pdes);

            return new DataResult<List<PriceDescriptionDTOs>>(pdesdtos,"Uğurla Əlavə Edildi", true);
        }

        public DataResult<List<PriceDescriptionDTOs>> TGetAll()
        {
            var pdes = _priceDescriptionRepository.GetAll();
            var pdesdtos = _mapper.Map<List<PriceDescriptionDTOs>>(pdes);

            return new DataResult<List<PriceDescriptionDTOs>>(pdesdtos, "Uğurla Əlavə Edildi", true);
        }

        public DataResult<PriceDescriptionDTOs> TGetById(int id)
        {
            var pdes = _priceDescriptionRepository.GetById(id);
            var pdesdtos = _mapper.Map<PriceDescriptionDTOs>(pdes);

            return new DataResult<PriceDescriptionDTOs>(pdesdtos, "Uğurla Əlavə Edildi", true);
        }

        public Result THardDelete(PriceDescriptionDTOs entity)
        {
            var pdes = _mapper.Map<PriceDescription>(entity);
            _priceDescriptionRepository.HardDelete(pdes);
            return new Result("Uğurla Əlavə Edildi", true);
        }

        public Result TUpdate(PriceDescriptionDTOs entity)
        {
            var pdes = _mapper.Map<PriceDescription>(entity);
            _priceDescriptionRepository.Update(pdes);
            return new Result("Uğurla Əlavə Edildi", true);
        }
        public DataResult<List<PriceDescriptionDTOs>> TGetActivByPricingId(int pricingId)
        {
            var pdes = _priceDescriptionRepository.GetActiv().Where(p => p.PricingId == pricingId).ToList();
            var pdesdtos = _mapper.Map<List<PriceDescriptionDTOs>>(pdes);

            return new DataResult<List<PriceDescriptionDTOs>>(pdesdtos, "Uğurla Əlavə Edildi", true);
        }

    }
}
