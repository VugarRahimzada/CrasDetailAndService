using BusinessLayer.Abstrsact;
using DTOLayer.ServiceDTO;
using DTOLayer.TeamDTO;
using FinalProjectVR.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPricingService _pricingService;
        private readonly ITeamService _teamService;
        private readonly IServiceService _serviceService;

        public HomeController(IPricingService pricingService, ITeamService teamService, IServiceService serviceService)
        {
            _pricingService = pricingService;
            _teamService = teamService;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var pricingdata = _pricingService.TGetActiv().Data;
            var teamdata = _teamService.TGetTeamHomePage().Data;
            var servicedata = _serviceService.TGetServiceHomePage().Data;
            HomeViewModel viewModel = new()
            {
                Pricings = pricingdata,
                Teams = teamdata,
                Services = servicedata
            };
            return View(viewModel);
        }
    }
}
