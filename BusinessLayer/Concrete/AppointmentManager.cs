using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.AppointmentDTO;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentManager(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public IResult TAdd(AppointmentDTOs entity)
        {
            var value = _mapper.Map<Appointment>(entity);
            _appointmentRepository.Add(value);
            return new SuccessResult(UIMessage.ADD_SUCCESS);

        }

        public IResult TDelete(AppointmentDTOs entity)
        {
            var value = _mapper.Map<Appointment>(entity);
            _appointmentRepository.Delete(value);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult THardDelete(AppointmentDTOs entity)
        {
            var value = _mapper.Map<Appointment>(entity);
            _appointmentRepository.HardDelete(value);
            return new SuccessResult(UIMessage.DELETE_SUCCESS); 
        }

        public IResult TUpdate(AppointmentDTOs entity)
        {
            var value = _mapper.Map<Appointment>(entity);
            _appointmentRepository.Update(value);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }
        public IDataResult<List<AppointmentDTOs>> TGetActiv()
        {
            var appointment = _appointmentRepository.GetActiv();
            var appointmentdto = _mapper.Map<List<AppointmentDTOs>>(appointment);
            return new SuccessDataResult<List<AppointmentDTOs>>(appointmentdto);
        }

        public IDataResult<List<AppointmentDTOs>> TGetAll()
        {
            var appointment = _appointmentRepository.GetAll();
            var appointmentdto = _mapper.Map<List<AppointmentDTOs>>(appointment);
            return new SuccessDataResult<List<AppointmentDTOs>>(appointmentdto);
        }

        public IDataResult<AppointmentDTOs> TGetById(int id)
        {
            var appointment = _appointmentRepository.GetById(id);
            var appointmentdto = _mapper.Map<AppointmentDTOs>(appointment);
            return new SuccessDataResult<AppointmentDTOs>(appointmentdto);
        }
    }
}
