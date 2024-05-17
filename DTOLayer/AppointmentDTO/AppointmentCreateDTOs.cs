﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.AppointmentDTO
{
    public class AppointmentCreateDTOs
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VehicelType { get; set; }
        public string Message { get; set; }
        public DateTime SelectDate { get; set; }
    }
}
