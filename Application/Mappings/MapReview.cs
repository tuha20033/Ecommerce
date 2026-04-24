using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapReview : AutoMapper.Profile
{
    public MapReview()
    {
        CreateMap<Review, ReviewDTO>().ReverseMap();
    }
}
