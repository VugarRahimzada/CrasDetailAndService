using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Extension;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.TeamDTO;
using EntityLayer.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using IResult = CoreLayer.Results.Abstract;
namespace BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {

        private readonly ITeamRepository _teamRepository;
        private readonly IValidator<Team> _validator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public TeamManager(ITeamRepository teamRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment, IValidator<Team> validator)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _validator = validator;
        }

        public IResult.IResult TAdd(TeamCreateDTOs entity, IFormFile photoUrl, out List<ValidationFailure> errors)
        {

            if (photoUrl == null)
            {
                errors = new List<ValidationFailure>();
                errors.Add(new ValidationFailure("photoUrl", UIMessage.ERROR_IMAGE_EMPTY));
                return new ErrorResult(UIMessage.ERROR_IMAGE_EMPTY);
            }

            entity.ImageUrl = PictureHelper.UploadImage(photoUrl, _webHostEnvironment.WebRootPath);
            var team = _mapper.Map<Team>(entity);
            var validationResult = _validator.Validate(team);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _teamRepository.Add(team);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }
      

        public IResult.IResult TDelete(TeamDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.Delete(team);

            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult.IResult THardDelete(TeamDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.HardDelete(team);

            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult.IResult TUpdate(TeamDTOs entity,IFormFile photoUrl, out List<ValidationFailure> errors)
        {
            var existData = TGetById(entity.Id).Data;
            if (photoUrl!= null)
            {
                entity.ImageUrl = PictureHelper.UploadImage(photoUrl, _webHostEnvironment.WebRootPath);
            }
            else
            {
                entity.ImageUrl = existData.ImageUrl;
            }
            var team = _mapper.Map<Team>(entity);
            var validationResult = _validator.Validate(team);
            errors = new List<ValidationFailure>();
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    errors.Add(item);
                }
                return new ErrorResult("Error");
            }
            _teamRepository.Update(team);

            return new SuccessResult(UIMessage.UPDATE_SUCCESS);
        }
        public IDataResult<List<TeamActiveDTOs>> TGetActiv()
        {
            var team = _teamRepository.GetActiv();
            var teamdto = _mapper.Map<List<TeamActiveDTOs>>(team);
            return new SuccessDataResult<List<TeamActiveDTOs>>(teamdto);

        }

        public IDataResult<List<TeamDTOs>> TGetAll()
        {
            var team = _teamRepository.GetAll();
            var teamdto = _mapper.Map<List<TeamDTOs>>(team);
            return new SuccessDataResult<List<TeamDTOs>>(teamdto);
        }

        public IDataResult<TeamDTOs> TGetById(int id)
        {
            var team = _teamRepository.GetById(id);
            var teamdto = _mapper.Map<TeamDTOs>(team);
            return new SuccessDataResult<TeamDTOs>(teamdto);
        }

        public IDataResult<List<TeamActiveDTOs>> TGetTeamHomePage()
        {
            var team = _teamRepository.GetTeamHomePage(x=>x.isHomePage==true).ToList();
            var teamdto = _mapper.Map<List<TeamActiveDTOs>>(team);
            return new SuccessDataResult<List<TeamActiveDTOs>>(teamdto);
        }


        public IDataResult<int> TCount()
        {
            var value = _teamRepository.GetActiv().Count();

            return new SuccessDataResult<int>(value);
        }
    }
}
