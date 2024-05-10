using AutoMapper;
using BusinessLayer.Abstrsact;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer;
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

        public IResult TAdd(PricingDTOs entity)
        {
            throw new NotImplementedException();
        }

        public IResult TDelete(PricingDTOs entity)
        {
            throw new NotImplementedException();
        }
        public IDataResult<List<PricingDTOs>> TGetActiv()
        {
            var pricing = _pricingRepository.GetActiv();
            var pricingdtos = _mapper.Map<List<PricingDTOs>>(pricing);

            return new SuccessDataResult<List<PricingDTOs>>(pricingdtos, "Uğurlu");

        }

        public IDataResult<List<PricingDTOs>> TGetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<PricingDTOs> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult THardDelete(PricingDTOs entity)
        {
            throw new NotImplementedException();
        }

        public IResult TUpdate(PricingDTOs entity)
        {
            throw new NotImplementedException();
        }

    }
}
