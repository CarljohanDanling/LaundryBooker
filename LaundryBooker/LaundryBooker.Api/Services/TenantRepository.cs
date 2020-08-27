namespace LaundryBooker.Api.Services
{
    using LaundryBooker.Api.Database.DatabaseContext;
    using LaundryBooker.Api.Database.DatabaseModels;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TenantRepository : ITenantRepository
    {
        private readonly LaundryContext _laundryContext;

        public TenantRepository(LaundryContext laundryContext)
        {
            _laundryContext = laundryContext;
        }

        public async Task<IEnumerable<Tenant>> GetTenants()
            => await _laundryContext.Tenants.ToListAsync();

        public async Task<Tenant> GetTenant(int tenantId)
            => await _laundryContext.Tenants
                        .Where(t => t.Id == tenantId)
                        .FirstOrDefaultAsync();

        public async Task<IEnumerable<BookingSession>> GetBookingSessionsForTenant(int tenantId)
            => await _laundryContext.BookingSessions
                    .Include(bs => bs.Tenant)
                    .Where(bs => bs.TenantId == tenantId).ToListAsync();
    }
}