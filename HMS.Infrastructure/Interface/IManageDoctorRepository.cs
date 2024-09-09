using HMS.Core.DoctorDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Interface
{
    public interface IManageDoctorRepository
    {
        List<ManageDoctor> GetAll();
        object Create(ManageDoctor manageDoctor);
        ManageDoctor GetById(int id);
        object Delete(int id);
        object Update(ManageDoctor manageDoctor);
    }
}
