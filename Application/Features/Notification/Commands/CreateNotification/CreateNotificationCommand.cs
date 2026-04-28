using Domain.Enums;
using MediatR;

namespace Application.Features.Notification.Commands.CreateNotification
{
    public class CreateNotificationCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public NotificationType Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public string? data { get; set; }
    }
}
