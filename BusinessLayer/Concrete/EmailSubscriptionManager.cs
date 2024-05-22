using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.EmailSubscriptionDTO;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmailSubscriptionManager : IEmailSubscriptionService
    {
        private readonly IEmailSubscriptionRepository _emailrepository;
        private readonly IMapper _mapper;

        public EmailSubscriptionManager(IEmailSubscriptionRepository emailrepository, IMapper mapper)
        {
            _emailrepository = emailrepository;
            _mapper = mapper;
        }

        public IResult TAdd(EmailSubscriptionCreateDTOs entity)
        {
            var value = _mapper.Map<EmailSubscription>(entity);
            _emailrepository.Add(value);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult TDelete(EmailSubscriptionDTOs entity)
        {
            var value = _mapper.Map<EmailSubscription>(entity);
            _emailrepository.Delete(value);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }
        public IResult THardDelete(EmailSubscriptionDTOs entity)
        {
            var value = _mapper.Map<EmailSubscription>(entity);
            _emailrepository.HardDelete(value);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(EmailSubscriptionDTOs entity)
        {
            var value = _mapper.Map<EmailSubscription>(entity);
            _emailrepository.Update(value);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }

        public IDataResult<List<EmailSubscriptionDTOs>> TGetActiv()
        {
            var email = _emailrepository.GetActiv();
            var emaildto = _mapper.Map<List<EmailSubscriptionDTOs>>(email);
            return new SuccessDataResult<List<EmailSubscriptionDTOs>>(emaildto);
        }

        public IDataResult<List<EmailSubscriptionDTOs>> TGetAll()
        {
            var email = _emailrepository.GetAll();
            var emaildto = _mapper.Map<List<EmailSubscriptionDTOs>>(email);
            return new SuccessDataResult<List<EmailSubscriptionDTOs>>(emaildto);
        }

        public IDataResult<EmailSubscriptionDTOs> TGetById(int id)
        {
            var email = _emailrepository.GetById(id);
            var emaildto = _mapper.Map<EmailSubscriptionDTOs>(email);
            return new SuccessDataResult<EmailSubscriptionDTOs>(emaildto);
        }
        public IDataResult<int> TCount()
        {
            var value = _emailrepository.GetActiv().Count();

            return new SuccessDataResult<int>(value);
        }
    }
}