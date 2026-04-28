using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Promotion.Commands.CreatePromotion
{
    public class CreatePromotionHandler : IRequestHandler<CreatePromotionCommand, Guid>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePromotionHandler(IPromotionRepository promotionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = _mapper.Map<Domain.Entities.Promotion>(request);
            await _promotionRepository.AddAsync(promotion, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return promotion.Id;
        }
    }
}
