using AutoMapper;
using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataAccessLayer.Abstract;
using DTOLayer.TeamDTO;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {

        private readonly ITeamRepository _teamRepository;

        private readonly IMapper _mapper;

        public TeamManager(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public IResult TAdd(TeamCreateDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.Add(team);

            return new SuccessResult(UIMessage.ADD_SUCCESS);
        }
      

        public IResult TDelete(TeamDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.Delete(team);

            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult THardDelete(TeamDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.HardDelete(team);

            return new SuccessResult(UIMessage.DELETE_SUCCESS);
        }

        public IResult TUpdate(TeamDTOs entity)
        {
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

    }
}
