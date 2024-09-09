using HMS.Core.Db;
using HMS.Core.PatientDetails;
using HMS.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Repository
{
    public class ManagePatientRepository:IManagePatientRepository
    {
        private readonly HMSDbContext _dbContext;

        public ManagePatientRepository(HMSDbContext context)
        {
            _dbContext = context;
        }

        public object Create(ManagePatient managePatient)
        {
            return _dbContext.ManagePatient.Add(managePatient);
        }

        public List<ManagePatient> GetAll()
        {
            return _dbContext.ManagePatient.Where(x => x.IsDeleted == false).ToList();
        }

        public ManagePatient GetById(int id)
        {
            return _dbContext.ManagePatient.FirstOrDefault(x => x.Id == id);
        }

        public object Update(ManagePatient managePatient)
        {
            var data = _dbContext.ManagePatient.FirstOrDefault(x => x.Id == managePatient.Id);
            if (data != null)
            {

                data.Name = managePatient.Name;
                data.Address = managePatient.Address;
                data.Email = managePatient.Email;
                data.ContactNo = managePatient.ContactNo;

            }
            return data;
        }

        public object Delete(int id)
        {
            var data = _dbContext.ManagePatient.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                //_dbContext.CandidateDetail.Remove(data);
                data.IsDeleted = true;

            }
            return data;
        }
    }
}
