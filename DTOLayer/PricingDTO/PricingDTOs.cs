﻿using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.PricingDTO
{
    public class PricingDTOs
    {
        public int Id { get; set; }
        public int Delete { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
