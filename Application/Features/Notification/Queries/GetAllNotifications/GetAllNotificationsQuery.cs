using Application.DTOs;
using MediatR;

namespace Application.Features.Notification.Queries.GetAllNotifications
{
    public class GetAllNotificationsQuery : IRequest<List<NotificationDTO>>
    {
    }
}
