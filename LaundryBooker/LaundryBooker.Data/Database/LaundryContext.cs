namespace LaundryBooker.Data.Database
{
    using LaundryBooker.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LaundryContext : DbContext
    {
        public LaundryContext(DbContextOptions<LaundryContext> options)
            : base(options)
        {
        }

        public DbSet<LaundryRoom> LaundryRooms { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<BookingSession> BookingSessions { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<HistoryLog> HistoryLogs { get; set; }
        public DbSet<CalendarReservation> CalendarReservations{ get; set; }
        public DbSet<ReservedSession> ReservedSessions { get; set; }
        public DbSet<AvailableSession> AvailableSessions { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Todo: Add relation config.
        }
    }
}
