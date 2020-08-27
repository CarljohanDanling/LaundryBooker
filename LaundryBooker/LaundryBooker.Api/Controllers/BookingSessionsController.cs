namespace LaundryBooker.Api.Controllers
{
    using LaundryBooker.Api.Dto;
    using LaundryBooker.Api.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/bookingsessions")]
    public class BookingSessionsController : ControllerBase
    {
        private readonly IBookingSessionRepository _bookingSessionRepository;

        public BookingSessionsController(IBookingSessionRepository bookingSessionRepository)
        {
            _bookingSessionRepository = bookingSessionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingSessions()
        {
            var bookingSessionsFromRepo = await _bookingSessionRepository.GetBookingSessions();
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

        [HttpGet("{bookingSessionId}")]
        public async Task<IActionResult> GetBookingSession(Guid bookingSessionId)
        {
            var bookingSessionFromRepo = await _bookingSessionRepository.GetBookingSession(bookingSessionId); ;
            var bookingSession = new BookingSessionDto
            {
                Id = bookingSessionFromRepo.Id,
                StartTime = bookingSessionFromRepo.StartTime.DateTime,
                EndTime = bookingSessionFromRepo.EndTime.DateTime,
                SessionStatus = bookingSessionFromRepo.SessionStatus.ToString(),
                TenantId = bookingSessionFromRepo.TenantId,
                LaundryRoomId = bookingSessionFromRepo.LaundryRoomId
            };

            return Ok(bookingSession);
        }
    }
}