namespace LaundryBooker.Web.Profiles
{
    using DataLayer.Models;
    using DataLayer.Database.DatabaseModels;
    using DataLayer.Dto;
    using Engine.Models;
    using Models;
    using AutoMapper;
    using Engine.Dto;
    using ViewModels;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ScheduleDto, ScheduleViewModel>();
            CreateMap<BookingSessionBL, BookingSessionModel>();
            CreateMap<BookingSession, BookingSessionDto>();
            CreateMap<AddBookingSessionDto, AddBookingSessionModel>();
            CreateMap<AddBookingSessionModel, BookingSession>();
            CreateMap<Building, BuildingDto>();
            CreateMap<LaundryRoom, LaundryRoomModel>();

            CreateMap<BuildingDto, BuildingModel>()
                .ForMember(bm => bm.BuildingName, bm => bm.MapFrom(b =>
                    $"{b.StreetAddress} {b.HouseNumber}{b.HousePrefix}"));
        }
    }
}