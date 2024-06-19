using BusinessLayer.Abstrsact;
using DTOLayer.PricingDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingController : BaseController
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingservice)
        {
            _pricingService = pricingservice;
        }
        [Authorize()]
        public IActionResult Index()
        {
            var pricing = _pricingService.TGetAll().Data;
            return View(pricing);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdatePricing(int id)
        {
            var pricing = _pricingService.TGetById(id).Data;
            return View(pricing);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdatePricing(PricingDTOs pricingDTOs)
        {
            var result = _pricingService.TUpdate(pricingDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(pricingDTOs);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddPricing()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddPricing(PricingCreateDTOs pricingDTOs)
        {
            var result = _pricingService.TAdd(pricingDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return  View(pricingDTOs);
            }
                return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult DeletePricing(int id)
        {
            var value = _pricingService.TGetById(id).Data;
            _pricingService.TDelete(value);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult HardDeletePricing(int id)
        {
            var value = _pricingService.TGetById(id).Data;
            _pricingService.THardDelete(value);
            return RedirectToAction("Index");

        }
    }
}
