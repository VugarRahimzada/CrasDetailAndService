using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Extension;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.TeamDTO;
using EntityLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using IResult = CoreLayer.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
namespace BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {

        private readonly ITeamRepository _teamRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public TeamManager(ITeamRepository teamRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public CoreLayer.Results.Abstract.IResult TAdd(TeamCreateDTOs entity, IFormFile photoUrl)
        {
            entity.ImageUrl = PictureHelper.UploadImage(photoUrl, _webHostEnvironment.WebRootPath);
            var team = _mapper.Map<Team>(entity);
            _teamRepository.Add(team);
            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }
      

        public CoreLayer.Results.Abstract.IResult TDelete(TeamDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.Delete(team);

            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public CoreLayer.Results.Abstract.IResult THardDelete(TeamDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.HardDelete(team);

            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public CoreLayer.Results.Abstract.IResult TUpdate(TeamDTOs entity,IFormFile photoUrl)
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
    }
}
