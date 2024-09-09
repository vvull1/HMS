using HMS.Core.Db;
using HMS.Core.DoctorDetails;
using HMS.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Repository
{
    public class ManageDoctorRepository : IManageDoctorRepository
    {
        private readonly HMSDbContext _dbContext;
        public ManageDoctorRepository(HMSDbContext context)
        {
            _dbContext = context;
        }

        public object Create(ManageDoctor manageDoctor)
        {
            return _dbContext.ManageDoctor.Add(manageDoctor);
        }

        public List<ManageDoctor> GetAll()
        {
            return _dbContext.ManageDoctor.Where(x => x.IsDeleted == false).ToList();
        }

        public ManageDoctor GetById(int id)
        {
            return _dbContext.ManageDoctor.FirstOrDefault(x => x.Id == id);
        }

        public object Update(ManageDoctor manageDoctor)
        {
            var data = _dbContext.ManageDoctor.FirstOrDefault(x => x.Id == manageDoctor.Id);
            if (data != null)
            {

                data.Name = manageDoctor.Name;
                data.Address = manageDoctor.Address;
                data.Email = manageDoctor.Email;
                data.ContactNo = manageDoctor.ContactNo;
                data.Date = manageDoctor.Date;
                data.Time = manageDoctor.Time;
                data.IsAvailable = manageDoctor.IsAvailable;

            }
            return data;
        }

        public object Delete(int id)
        {
            var data = _dbContext.ManageDoctor.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                //_dbContext.CandidateDetail.Remove(data);
                data.IsDeleted = true;

            }
            return data;
        }
    }
}
