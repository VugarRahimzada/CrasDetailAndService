using BusinessLayer.Abstrsact;
using DTOLayer;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PriceDescriptionController : Controller
    {
         private readonly IPriceDescriptionsService _priceDescriptionsService;
        private readonly IPricingService _pricingService;

        public PriceDescriptionController(IPriceDescriptionsService priceDescriptionsService, IPricingService pricingService)
        {
            _priceDescriptionsService = priceDescriptionsService;
            _pricingService = pricingService;
        }

        public IActionResult Index()
        {
            var value = _priceDescriptionsService.TGetOrderWithPricingCategory().Data;
            return View(value);
        }

        [HttpGet]
        public IActionResult AddPDescription()
        {
            ViewData["PriceDescription"] = _pricingService.TGetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult AddPDescription(PriceDescriptionDTOs priceDescriptionDTOs)
        {
            var result = _priceDescriptionsService.TAdd(priceDescriptionDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(priceDescriptionDTOs);
        }


        [HttpGet]
        public IActionResult UpdatePDescription(int id)
        {
            var teamMember = _priceDescriptionsService.TGetById(id).Data;
            return View(teamMember);
        }

        [HttpPost]
        public IActionResult UpdatePDescription(PriceDescriptionDTOs priceDescriptionDTOs)
        {
            var result = _priceDescriptionsService.TUpdate(priceDescriptionDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(priceDescriptionDTOs);
        }

        public IActionResult DeletePDescription(int id)
        {
            var pdescription = _priceDescriptionsService.TGetById(id).Data;
            _priceDescriptionsService.TDelete(pdescription);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult HardDeletePDescription(int id)
        {
            var pdescription = _priceDescriptionsService.TGetById(id).Data;
            _priceDescriptionsService.THardDelete(pdescription);
            return RedirectToAction("Index");
        }
    }
}
