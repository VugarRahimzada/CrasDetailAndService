using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.AboutDTO;
using EntityLayer.Models;
using FluentValidation;
using FluentValidation.Results;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IValidator<About> _validator;
        private readonly IMapper _mapper;

        public AboutManager(IAboutRepository aboutRepository, IMapper mapper, IValidator<About> aboutValidator)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
            _validator = aboutValidator;
        }

        public IResult TAdd(AboutCreateDTOs entity, out List<ValidationFailure> errors)
        {
            var about = _mapper.Map<About>(entity);
            var validationResult = _validator.Validate(about);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _aboutRepository.Add(about);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }

        public IResult TDelete(AboutDTOs entity)
        {
            var about = _mapper.Map<About>(entity);
            _aboutRepository.Delete(about);
            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(AboutUpdateDTOs entity, out List<ValidationFailure> errors)
        {
            var about = _mapper.Map<About>(entity);
            var validationResult = _validator.Validate(about);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _aboutRepository.Update(about);
            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }




        public IDataResult<List<AboutGetActivDTOs>> TGetActiv()
        {
            var about = _aboutRepository.GetActiv();
            var aboutdtos = _mapper.Map<List<AboutGetActivDTOs>>(about);

            return new SuccessDataResult<List<AboutGetActivDTOs>>(aboutdtos);
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
