using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
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
    public class AboutManager : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;

        public AboutManager(IAboutRepository aboutRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
        }

        public IResult TAdd(AboutDTOs entity)
        {
            var about = _mapper.Map<About>(entity);
            _aboutRepository.Add(about);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult TDelete(AboutDTOs entity)
        {
            var about = _mapper.Map<About>(entity);
            _aboutRepository.Delete(about);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult THardDelete(AboutDTOs entity)
        {
            var about = _mapper.Map<About>(entity);
            _aboutRepository.HardDelete(about);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(AboutDTOs entity)
        {
            var about = _mapper.Map<About>(entity);
            _aboutRepository.Update(about);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }
        public IDataResult<List<AboutDTOs>> TGetActiv()
        {
            var about = _aboutRepository.GetActiv();
            var aboutdtos = _mapper.Map<List<AboutDTOs>>(about);

            return new SuccessDataResult<List<AboutDTOs>>(aboutdtos);
        }

        public IDataResult<List<AboutDTOs>> TGetAll()
        {
            var about = _aboutRepository.GetAll();
            var aboutdtos = _mapper.Map<List<AboutDTOs>>(about);

            return new SuccessDataResult<List<AboutDTOs>>(aboutdtos);
        }

        public IDataResult<AboutDTOs> TGetById(int id)
        {
            var about = _aboutRepository.GetById(id);
            var aboutdtos = _mapper.Map<AboutDTOs>(about);

            return new SuccessDataResult<AboutDTOs>(aboutdtos);
        }

    }
}
