namespace LaundryBooker.Api.Services
{
    using LaundryBooker.Api.Database.DatabaseModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITenantRepository
    {
        public Task<IEnumerable<Tenant>> GetTenants();
        public Task<Tenant> GetTenant(int tenantId);
        public Task<IEnumerable<BookingSession>> GetBookingSessionsForTenant(int tenantId);
    }
}