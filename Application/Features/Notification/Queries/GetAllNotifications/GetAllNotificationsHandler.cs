using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Notification.Queries.GetAllNotifications
{
    public class GetAllNotificationsHandler : IRequestHandler<GetAllNotificationsQuery, List<NotificationDTO>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetAllNotificationsHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<List<NotificationDTO>> Handle(GetAllNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<NotificationDTO>>(notifications.ToList());
        }
    }
}
