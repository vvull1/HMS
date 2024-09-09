using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Interface
{
    public interface IUnitOfWork
    {

        IManagePatientRepository ManagePatient { get; }
        IManageDoctorRepository ManageDoctor { get; }
        IManageAppointmentRepository ManageAppointment { get; }

        void Commit();
        Task CommitAsync();
    }
}
