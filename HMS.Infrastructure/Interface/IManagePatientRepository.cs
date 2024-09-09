using HMS.Core.PatientDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Interface
{
    public interface IManagePatientRepository
    {
        List<ManagePatient> GetAll();
        object Create(ManagePatient managePatient);
        ManagePatient GetById(int id);
        object Delete(int id);
        object Update(ManagePatient managePatient);
    }
}
