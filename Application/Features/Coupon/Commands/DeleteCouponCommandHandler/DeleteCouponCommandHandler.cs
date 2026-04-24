

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace Application.Features.Coupon.Commands.DeleteCouponCommandHandler;

public class DeleteCouponCommandHandler : IRequestHandler<DeleteCouponCommand, bool>
{
    private readonly ILogger<DeleteCouponCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICouponRepository _couponRepository;
    public DeleteCouponCommandHandler(ILogger<DeleteCouponCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork, ICouponRepository couponRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _couponRepository = couponRepository;
    }

    public async Task<bool> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
    {
        if(request.Id == Guid.Empty)
        {
            _logger.LogError("Invalid coupon id: {Id}", request.Id);
            return false;
        }
        var coupon = await _couponRepository.GetByIdAsync(request.Id,cancellationToken);
        if (coupon == null)
        {
            _logger.LogError("Coupon with id {Id} not found", request.Id);
            return false;
        }
        await _couponRepository.DeleteAsync(coupon.Id,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
