using BusinessLayer.Abstrsact;
using CoreLayer.Results.Concrete;
using DocumentFormat.OpenXml.Math;
using DTOLayer.PricingDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PricingController : BaseController
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingservice)
        {
            _pricingService = pricingservice;
        }

        public IActionResult Index()
        {
            var pricing = _pricingService.TGetAll().Data;
            return View(pricing);
        }

        [HttpGet]
        public IActionResult UpdatePricing(int id)
        {
            var pricing = _pricingService.TGetById(id).Data;
            return View(pricing);
        }

        [HttpPost]
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
        public IActionResult AddPricing()
        {
            return View();
        }

        [HttpPost]
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
        
        public IActionResult DeletePricing(int id)
        {
            var value = _pricingService.TGetById(id).Data;
            _pricingService.TDelete(value);
            return RedirectToAction("Index");

        }
        public IActionResult HardDeletePricing(int id)
        {
            var value = _pricingService.TGetById(id).Data;
            _pricingService.THardDelete(value);
            return RedirectToAction("Index");

        }
    }
}
