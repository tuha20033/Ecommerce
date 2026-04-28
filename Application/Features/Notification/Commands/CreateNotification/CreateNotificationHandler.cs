using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notification.Commands.CreateNotification
{
    public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand, Guid>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateNotificationHandler(INotificationRepository notificationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<Domain.Entities.Notification>(request);
            await _notificationRepository.AddAsync(notification, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return notification.Id;
        }
    }
}
