using HotelReservationsManager.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationsManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
       // public virtual DbSet<ClientReservation> ClientsReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ClientReservation>()
            //     .HasKey(k => new { k.ReservationId, k.ClientId });
            builder.Entity<Reservation>()
                .HasMany(r => r.Clients);

            builder.Entity<Client>()
                .HasMany(c => c.Reservations);

            base.OnModelCreating(builder);
        }
    }
}