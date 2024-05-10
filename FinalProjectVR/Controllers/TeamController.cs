using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace FinalProjectVR.Controllers
{
    public class TeamController : Controller
    {

        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var value = _teamService.TGetActiv().Data;
            return View(value);
        }
    }
}
