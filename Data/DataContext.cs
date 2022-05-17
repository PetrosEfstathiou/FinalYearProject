using FinalYearProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalYearProject.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Xray> Xrays {get;set;}
    }
}