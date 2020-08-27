namespace LaundryBooker.Api.Database.DatabaseContext
{
    using LaundryBooker.Api.Database.DatabaseModels;
    using LaundryBooker.Api.Database.Enumerations;
    using Microsoft.EntityFrameworkCore;
    using System;

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

            modelBuilder.Entity<Tenant>()
                .HasMany(t => t.BookingSessions)
                .WithOne(bs => bs.Tenant)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LaundryRoom>()
                .HasOne(lr => lr.Building)
                .WithOne(b => b.LaundryRoom);

            modelBuilder.Entity<LaundryRoom>()
                .Property(lr => lr.RoomStatus)
                .HasConversion<string>();

            modelBuilder.Entity<LaundryRoom>()
                .HasMany(lr => lr.BookingSessions)
                .WithOne(bs => bs.LaundryRoom)
                .HasForeignKey(bs => bs.LaundryRoomId);

            modelBuilder.Entity<BookingSession>()
                .Property(bs => bs.SessionStatus)
                .HasConversion<string>();

            // SEED DATA
            modelBuilder.Entity<Building>().HasData(
                new Building()
                {
                    Id = 1,
                    StreetAddress = "Helenius Gata",
                    HouseNumber = 48,
                    HousePrefix = 'B'
                });

            modelBuilder.Entity<Apartment>().HasData(
                new Apartment()
                {
                    Id = 2,
                    ApartmentNumber = 14,
                    BuildingId = 1,
                });

            modelBuilder.Entity<Tenant>().HasData(
                new Tenant()
                {
                    Id = 1,
                    Name = "Calle",
                    ApartmentId = 2
                });

            modelBuilder.Entity<LaundryRoom>().HasData(
                new LaundryRoom()
                {
                    Id = 23,
                    BuildingId = 1,
                    RoomStatus = LaundryRoomStatus.Free
                });

            modelBuilder.Entity<BookingSession>().HasData(
                new BookingSession()
                {
                    Id = Guid.Parse("0306d7f7-b0ca-4937-950a-6f73e278792b"),
                    StartTime = new DateTimeOffset(2020, 06, 14, 14, 00, 00, new TimeSpan(2, 0, 0)),
                    EndTime = new DateTimeOffset(2020, 06, 14, 21, 00, 00, new TimeSpan(2, 0, 0)),
                    TenantId = 1,
                    LaundryRoomId = 23,
                    SessionStatus = BookingSessionStatus.Finished
                });

            modelBuilder.Entity<BookingSession>().HasData(
                new BookingSession()
                {
                    Id = Guid.Parse("09dd120c-286b-4891-a8df-7cd616dd65cb"),
                    StartTime = new DateTimeOffset(2020, 06, 19, 14, 00, 00, new TimeSpan(2, 0, 0)),
                    EndTime = new DateTimeOffset(2020, 06, 19, 21, 00, 00, new TimeSpan(2, 0, 0)),
                    TenantId = 1,
                    LaundryRoomId = 23,
                    SessionStatus = BookingSessionStatus.Scheduled
                });
        }
    }
}