using HMS.Core.AppointmentDetails;
using HMS.Core.Db;
using HMS.Core.DoctorDetails;
using HMS.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Repository
{
    public class ManageAppointmentRepository : IManageAppointmentRepository
    {
        private readonly HMSDbContext _dbContext;
        public ManageAppointmentRepository(HMSDbContext context)
        {
            _dbContext = context;
        }

        public object Create(ManageAppointment manageAppointment)
        {
            return _dbContext.ManageAppointment.Add(manageAppointment);
        }

        public List<ManageAppointment> GetAll()
        {
            return _dbContext.ManageAppointment.Where(x => x.IsDeleted == false).ToList();
        }

        public List<ManageAppointment> GetAppointmentDetails()
        {
            return _dbContext.ManageAppointment.Include(a => a.managePatient).Include(a => a.manageDoctor).Where(x => x.IsDeleted == false).ToList();
        }

        public ManageAppointment GetById(int id)
        {
            return _dbContext.ManageAppointment.FirstOrDefault(x => x.Id == id);
        }

        public object Update(ManageAppointment manageAppointment)
        {
            var data = _dbContext.ManageAppointment.FirstOrDefault(x => x.Id == manageAppointment.Id);
            if (data != null)
            {

                data.PatientId = manageAppointment.PatientId;
                data.DoctorId = manageAppointment.DoctorId;
                data.AppointmentDate = manageAppointment.AppointmentDate;
                data.AppointmentTime = manageAppointment.AppointmentTime;
                data.Description = manageAppointment.Description;
            }
            return data;
        }

        public object Delete(int id)
        {
            var data = _dbContext.ManageAppointment.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                //_dbContext.CandidateDetail.Remove(data);
                data.IsDeleted = true;

            }
            return data;
        }
    }
}
