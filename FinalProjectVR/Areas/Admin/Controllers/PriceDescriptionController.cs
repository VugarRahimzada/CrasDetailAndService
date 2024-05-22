using BusinessLayer.Abstrsact;
using DTOLayer.AboutDTO;
using DTOLayer.PriceDescriptionDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PriceDescriptionController : BaseController
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
        public IActionResult AddPDescription(PricingDescriptionCreateDTOs priceDescriptionDTOs)
        {
            var result = _priceDescriptionsService.TAdd(priceDescriptionDTOs,out List<ValidationFailure> errors);
            ViewData["PriceDescription"] = _pricingService.TGetAll().Data;
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(priceDescriptionDTOs);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdatePDescription(int id)
        {
    
            ViewData["PriceDescription"] = _pricingService.TGetAll().Data;
            var teamMember = _priceDescriptionsService.TGetById(id).Data;
            return View(teamMember);
        }

        [HttpPost]
        public IActionResult UpdatePDescription(PriceDescriptionDTOs priceDescriptionDTOs)
        {
            var result = _priceDescriptionsService.TUpdate(priceDescriptionDTOs, out List<ValidationFailure> errors);
            ViewData["PriceDescription"] = _pricingService.TGetAll().Data;
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(priceDescriptionDTOs);
            }
            return RedirectToAction("Index");
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
