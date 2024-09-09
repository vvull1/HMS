﻿using HMS.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.DoctorDetails
{
    public class ManageDoctor : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public bool IsAvailable { get; set; }
    }
}
