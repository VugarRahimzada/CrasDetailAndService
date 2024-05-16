using BusinessLayer.Abstrsact;
using DTOLayer.ServiceDTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var services = _serviceService.TGetAll().Data;
            return View(services);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(ServiceCreateDTOs serviceDTOs)
        {
            var result = _serviceService.TAdd(serviceDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var service = _serviceService.TGetById(id).Data;
            return View(service);
        }

        [HttpPost]
        public IActionResult UpdateService(ServiceDTOs serviceDTOs)
        {
            var result = _serviceService.TUpdate(serviceDTOs);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(serviceDTOs);
        }

        public IActionResult DeleteService(int id)
        {
            var service = _serviceService.TGetById(id).Data;
            _serviceService.TDelete(service);
            return RedirectToAction("Index");
        }
        public IActionResult HardDeleteService(int id)
        {
            var service = _serviceService.TGetById(id).Data;
            _serviceService.THardDelete(service);
            return RedirectToAction("Index");
        }

    }
}
