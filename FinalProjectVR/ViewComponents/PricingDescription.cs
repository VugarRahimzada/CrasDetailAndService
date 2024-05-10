using BusinessLayer.Abstrsact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectVR.ViewComponents
{
    public class PricingDescription : ViewComponent
    {
        private readonly IPriceDescriptionsService _pricingdescriptionService;

        public PricingDescription(IPriceDescriptionsService priceDescriptionsService)
        {
            _pricingdescriptionService = priceDescriptionsService;
        }

        public IViewComponentResult Invoke(int pricingId)
        {
            var value = _pricingdescriptionService.TGetActivByPricingId(pricingId).Data;
            return View(value);
        }
    }
}
