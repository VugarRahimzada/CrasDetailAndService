using DTOLayer.PricingDTO;
using DTOLayer.ServiceDTO;
using DTOLayer.TeamDTO;
using System.Collections.Generic;
using EntityLayer.Models;

namespace FinalProjectVR.ViewModels
{
    public class HomeViewModel
    {
        public List<PricingActivDTOs> Pricings { get; set; }
        public List<TeamActiveDTOs> Teams { get; set; }
        public List<ServiceActivDTOs> Services { get; set; }
    }
}
