using BusinessLayer.Abstrsact;
using DTOLayer.AboutDTO;
using DTOLayer.PriceDescriptionDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PriceDescriptionController : BaseController
    {
         private readonly IPriceDescriptionsService _priceDescriptionsService;
        private readonly IPricingService _pricingService;

        public PriceDescriptionController(IPriceDescriptionsService priceDescriptionsService, IPricingService pricingService)
        {
            _priceDescriptionsService = priceDescriptionsService;
            _pricingService = pricingService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var value = _priceDescriptionsService.TGetOrderWithPricingCategory().Data;
            return View(value);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddPDescription()
        {
            ViewData["PriceDescription"] = _pricingService.TGetAll().Data;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
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
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdatePDescription(int id)
        {
    
            ViewData["PriceDescription"] = _pricingService.TGetAll().Data;
            var teamMember = _priceDescriptionsService.TGetById(id).Data;
            return View(teamMember);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
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
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult DeletePDescription(int id)
        {
            var pdescription = _priceDescriptionsService.TGetById(id).Data;
            _priceDescriptionsService.TDelete(pdescription);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult HardDeletePDescription(int id)
        {
            var pdescription = _priceDescriptionsService.TGetById(id).Data;
            _priceDescriptionsService.THardDelete(pdescription);
            return RedirectToAction("Index");
        }
    }
}
