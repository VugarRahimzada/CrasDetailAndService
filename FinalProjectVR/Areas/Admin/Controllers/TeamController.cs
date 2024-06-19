using BusinessLayer.Abstrsact;
using BusinessLayer.BaseMessage;
using DTOLayer.AboutDTO;
using DTOLayer.TeamDTO;
using DTOLayer.TestimonialDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [Authorize()]
        public IActionResult Index()
        {
            var teamMembers = _teamService.TGetAll().Data;
            return View(teamMembers);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddTeam(TeamCreateDTOs teamcreateDTOs, IFormFile photoUrl)
        {
            var result = _teamService.TAdd(teamcreateDTOs, photoUrl, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(teamcreateDTOs);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdateTeam(int id)
        {
            var teamMember = _teamService.TGetById(id).Data;
            return View(teamMember);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdateTeam(TeamDTOs teamDTOs, IFormFile photoUrl)
        {
            var result = _teamService.TUpdate(teamDTOs, photoUrl, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(teamDTOs);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult DeleteTeam(int id)
        {
            var teamMember = _teamService.TGetById(id).Data;
            _teamService.TDelete(teamMember);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult HardDeleteTeam(int id)
        {
            var teamMember = _teamService.TGetById(id).Data;
            _teamService.THardDelete(teamMember);
            return RedirectToAction("Index");
        }

    }
}