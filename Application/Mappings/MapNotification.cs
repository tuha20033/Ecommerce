using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapNotification : AutoMapper.Profile
{
    public MapNotification()
    {
        CreateMap<Notification, NotificationDTO>().ReverseMap();
    }
}
