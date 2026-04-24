using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapReviewMedia : AutoMapper.Profile
{
    public MapReviewMedia()
    {
        CreateMap<ReviewMedia, ReviewMediaDTO>().ReverseMap();
    }
}
