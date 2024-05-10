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
    public class TeamManager : ITeamService
    {

        private readonly ITeamRepository _teamRepository;

        private readonly IMapper _mapper;

        public TeamManager(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public Result TAdd(TeamDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.Add(team);

            return new Result("Uğurla Əlavə Edildi", true);
        }
      

        public Result TDelete(TeamDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.Delete(team);

            return new Result("Uğurla Əlavə Edildi", true);
        }

        public Result THardDelete(TeamDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.HardDelete(team);

            return new Result("Uğurla Əlavə Edildi", true);
        }

        public Result TUpdate(TeamDTOs entity)
        {
            var team = _mapper.Map<Team>(entity);
            _teamRepository.Update(team);

            return new Result("Uğurla Əlavə Edildi", true);
        }
        public DataResult<List<TeamDTOs>> TGetActiv()
        {
            var team = _teamRepository.GetActiv();
            var teamdto = _mapper.Map<List<TeamDTOs>>(team);
            return new DataResult<List<TeamDTOs>>(teamdto,"Uğurlu",true);

        }

        public DataResult<List<TeamDTOs>> TGetAll()
        {
            var team = _teamRepository.GetAll();
            var teamdto = _mapper.Map<List<TeamDTOs>>(team);
            return new DataResult<List<TeamDTOs>>(teamdto, "Uğurlu", true);
        }

        public DataResult<TeamDTOs> TGetById(int id)
        {
            var team = _teamRepository.GetById(id);
            var teamdto = _mapper.Map<TeamDTOs>(team);
            return new DataResult<TeamDTOs>(teamdto, "Uğurlu", true);
        }

    }
}
