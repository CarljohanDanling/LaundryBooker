namespace LaundryBooker.DataLayer.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Database.DatabaseContext;
    using Database.DatabaseModels;
    using Microsoft.EntityFrameworkCore;

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
    }
}