

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Cart.Commands.CreatCartCommamdHandler;

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Guid>
{ 
    private readonly ICartRepository _cartRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
       var cart = _mapper.Map<Domain.Entities.Cart>(request);
       await  _cartRepository.AddAsync(cart, cancellationToken);
       await _unitOfWork.SaveChangesAsync(cancellationToken);
       return cart.Id;
    }
}
