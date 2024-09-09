using HMS.Core.Base;
using HMS.Core.DoctorDetails;
using HMS.Core.PatientDetails;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.AppointmentDetails
{
    public class ManageAppointment : BaseModel
    {
        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        [ValidateNever]
        public ManagePatient? managePatient { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey(nameof(DoctorId))]
        [ValidateNever]
        public ManageDoctor? manageDoctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string? Description { get; set; }
    }
}
