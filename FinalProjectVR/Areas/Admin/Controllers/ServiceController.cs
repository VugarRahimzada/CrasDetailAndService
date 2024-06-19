using BusinessLayer.Abstrsact;
using DTOLayer.ServiceDTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : BaseController
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [Authorize()]
        public IActionResult Index()
        {
            var services = _serviceService.TGetAll().Data;
            return View(services);
        }
        [HttpGet]

        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult AddService(ServiceCreateDTOs serviceDTOs)
        {
            var result = _serviceService.TAdd(serviceDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(serviceDTOs);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdateService(int id)
        {
            var service = _serviceService.TGetById(id).Data;
            return View(service);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult UpdateService(ServiceDTOs serviceDTOs)
        {
            var result = _serviceService.TUpdate(serviceDTOs, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                AddModelError(errors);
                return View(serviceDTOs);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult DeleteService(int id)
        {
            var service = _serviceService.TGetById(id).Data;
            _serviceService.TDelete(service);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Creator")]
        public IActionResult HardDeleteService(int id)
        {
            var service = _serviceService.TGetById(id).Data;
            _serviceService.THardDelete(service);
            return RedirectToAction("Index");
        }

    }
}
