namespace LaundryBooker.DataLayer.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Database.DatabaseModels;

    public interface ITenantRepository
    {
        Task<IEnumerable<Tenant>> GetTenants();
        Task<Tenant> GetTenant(int tenantId);
    }
}