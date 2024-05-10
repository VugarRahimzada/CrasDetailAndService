using AutoMapper;
using BusinessLayer.Abstrsact;
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

        public Result TAdd(PricingDTOs entity)
        {
            throw new NotImplementedException();
        }

        public Result TDelete(PricingDTOs entity)
        {
            throw new NotImplementedException();
        }
        public DataResult<List<PricingDTOs>> TGetActiv()
        {
            var pricing = _pricingRepository.GetActiv();
            var pricingdtos = _mapper.Map<List<PricingDTOs>>(pricing);

            return new DataResult<List<PricingDTOs>>(pricingdtos, "Uğurlu", true);

        }

        public DataResult<List<PricingDTOs>> TGetAll()
        {
            throw new NotImplementedException();
        }

        public DataResult<PricingDTOs> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Result THardDelete(PricingDTOs entity)
        {
            throw new NotImplementedException();
        }

        public Result TUpdate(PricingDTOs entity)
        {
            throw new NotImplementedException();
        }

    }
}
