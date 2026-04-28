using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Review.Queries.GetAllReviews
{
    public class GetAllReviewsHandler : IRequestHandler<GetAllReviewsQuery, List<ReviewDTO>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetAllReviewsHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<List<ReviewDTO>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<ReviewDTO>>(reviews.ToList());
        }
    }
}
