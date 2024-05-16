using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.ServiceDTO;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceManager(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public IResult TAdd(ServiceCreateDTOs entity)
        {
            var value = _mapper.Map<Service>(entity);
            _serviceRepository.Add(value);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult TDelete(ServiceDTOs entity)
        {
            var value = _mapper.Map<Service>(entity);
            _serviceRepository.Delete(value);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IDataResult<List<ServiceActivDTOs>> TGetActiv()
        {
            var service = _serviceRepository.GetActiv();
            var servicedal = _mapper.Map<List<ServiceActivDTOs>>(service);
            return new SuccessDataResult<List<ServiceActivDTOs>>(servicedal, UIMessage.SUCCESS);
        }

        public IDataResult<List<ServiceDTOs>> TGetAll()
        {
            var service = _serviceRepository.GetAll();
            var servicedal = _mapper.Map<List<ServiceDTOs>>(service);
            return new SuccessDataResult<List<ServiceDTOs>>(servicedal, UIMessage.SUCCESS);
        }

        public IDataResult<ServiceDTOs> TGetById(int id)
        {
            var service = _serviceRepository.GetById(id);
            var servicedal = _mapper.Map<ServiceDTOs>(service);
            return new SuccessDataResult<ServiceDTOs>(servicedal, UIMessage.SUCCESS);
        }

        public IResult THardDelete(ServiceDTOs entity)
        {
            var value = _mapper.Map<Service>(entity);
            _serviceRepository.HardDelete(value);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(ServiceDTOs entity)
        {
            var value = _mapper.Map<Service>(entity);
            _serviceRepository.Update(value);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }
    }
}
