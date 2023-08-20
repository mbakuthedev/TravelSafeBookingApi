using Microsoft.EntityFrameworkCore;
using TravelSafeBookingApi.DataModels;

namespace TravelSafeBookingApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CustomerDataModel> Customers { get; set; }
        public DbSet<ReservationDataModel> Reservations { get; set; }
        public DbSet<BusRoutesDataModel> BusRoutes { get; set; }
        public DbSet<BusesDataModel> Buses { get; set; }
        public DbSet<StatesDataModel> StatesInfo { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
         
            base.OnModelCreating(builder);
        }
    }
}
