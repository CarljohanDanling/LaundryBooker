namespace LaundryBooker.Api.Database.DatabaseContext
{
    using LaundryBooker.Api.Database.DatabaseModels;
    using Microsoft.EntityFrameworkCore;

    public class LaundryContext : DbContext
    {
        public LaundryContext(DbContextOptions<LaundryContext> options)
            : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<LaundryRoom> LaundryRooms { get; set; }
        public DbSet<BookingSession> BookingSessions { get; set; }

        // To be implemented:
        //public DbSet<AvailableSession> AvailableSessions { get; set; }
        //public DbSet<ReservedSession> ReservedSessions { get; set; }
        //public DbSet<CalendarReservation> CalendarReservations { get; set; }
        //public DbSet<HistoryLog> HistoryLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>()
                .HasMany(b => b.Apartments)
                .WithOne(a => a.Building)
                .IsRequired();

            modelBuilder.Entity<Apartment>()
                .HasOne(a => a.Tenant)
                .WithOne(t => t.Apartment)
                .HasForeignKey<Tenant>(t => t.ApartmentId);

            modelBuilder.Entity<LaundryRoom>()
                .HasOne(lr => lr.Building)
                .WithOne(b => b.LaundryRoom);

            modelBuilder.Entity<LaundryRoom>()
                .HasMany(lr => lr.BookingSessions)
                .WithOne(bs => bs.LaundryRoom)
                .HasForeignKey(bs => bs.LaundryRoomId);
        }
    }
}