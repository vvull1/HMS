using HMS.Core.AppointmentDetails;
using HMS.Core.DoctorDetails;
using HMS.Core.PatientDetails;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Db
{
    public class HMSDbContext: DbContext
    {
        public HMSDbContext(DbContextOptions<HMSDbContext> options) : base(options)
        {

        }        

        public DbSet<ManagePatient> ManagePatient { get; set; }
        public DbSet<ManageDoctor> ManageDoctor { get; set; }
        public DbSet<ManageAppointment> ManageAppointment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
