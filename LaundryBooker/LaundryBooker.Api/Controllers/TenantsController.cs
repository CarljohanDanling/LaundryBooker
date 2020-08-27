namespace LaundryBooker.Api.Controllers
{
    using LaundryBooker.Api.Dto;
    using LaundryBooker.Api.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/tenants")]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantsController(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTenants()
        {
            var tenantsFromRepo = await _tenantRepository.GetTenants();
            var tenants = new List<TenantDto>();

            tenantsFromRepo.ToList().ForEach(t => tenants
                .Add(new TenantDto 
                    {
                        Id = t.Id,
                        Name = t.Name
                    }));

            return Ok(tenants);
        }

        [HttpGet("{tenantId}")]
        public async Task<IActionResult> GetTenant(int tenantId)
        {
            var tenantFromRepo = await _tenantRepository.GetTenant(tenantId);
            var tenant = new TenantDto
            {
                Id = tenantFromRepo.Id,
                Name = tenantFromRepo.Name
            };

            return Ok(tenant);
        }

        [HttpGet("{tenantId}/bookingsessions")]
        public async Task<IActionResult> GetBookingSessionsForTenant(int tenantId)
        {
            var bookingSessionsFromRepo = await _tenantRepository.GetBookingSessionsForTenant(tenantId);
            var bookingSessions = new List<BookingSessionDto>();

            bookingSessionsFromRepo.ToList().ForEach(bs => bookingSessions
                .Add(new BookingSessionDto
                {
                    Id = bs.Id,
                    StartTime = bs.StartTime.DateTime,
                    EndTime = bs.EndTime.DateTime,
                    SessionStatus = bs.SessionStatus.ToString(),
                    TenantId = bs.TenantId,
                    LaundryRoomId = bs.LaundryRoomId
                }));

            return Ok(bookingSessions);
        }
    }
}