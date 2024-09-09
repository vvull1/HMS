using HMS.Core.AppointmentDetails;
using HMS.Core.DoctorDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Interface
{
    public interface IManageAppointmentRepository
    {
        List<ManageAppointment> GetAll();
        object Create(ManageAppointment manageAppointment);
        ManageAppointment GetById(int id);
        object Delete(int id);
        object Update(ManageAppointment manageAppointment);
        List<ManageAppointment>  GetAppointmentDetails();
    }
}
