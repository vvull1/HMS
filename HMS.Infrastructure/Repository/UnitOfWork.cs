using HMS.Core.Db;
using HMS.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly HMSDbContext _db;

        public IManagePatientRepository ManagePatient { get; set; }

        public IManageDoctorRepository ManageDoctor { get; set; }

        public IManageAppointmentRepository ManageAppointment { get; set; }

        public UnitOfWork(HMSDbContext db)
        {
            _db = db;
            ManagePatient = new ManagePatientRepository(_db);
            ManageDoctor = new ManageDoctorRepository(_db);
            ManageAppointment = new ManageAppointmentRepository(_db);
        }
        public void Commit()
        {
            _db.SaveChanges();
        }
        public void Commit(object? newObj)
        {
            _db.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
