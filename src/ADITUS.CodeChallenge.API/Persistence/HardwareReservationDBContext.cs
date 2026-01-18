using ADITUS.CodeChallenge.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace ADITUS.CodeChallenge.API.Persistence;

public class HardwareReservationDBContext : DbContext
{

        public HardwareReservationDBContext(DbContextOptions<HardwareReservationDBContext> options) : base(options) { }

        public DbSet<HardwareReservation> HardwareReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<HardwareReservation>()
                    .HasKey(r => r.EventId); //with the events given in a predefined list, this is a pseudo foreign key
        }

}