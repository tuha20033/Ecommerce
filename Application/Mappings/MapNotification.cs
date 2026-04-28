using Application.DTOs;
using Application.Features.Notification.Commands.CreateNotification;
using Domain.Entities;

namespace Application.Mappings;

public class MapNotification : AutoMapper.Profile
{
    public MapNotification()
    {
        CreateMap<Notification, NotificationDTO>().ReverseMap();
        CreateMap<CreateNotificationCommand, Notification>();
    }
}
