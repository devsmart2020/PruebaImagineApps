using AutoMapper;
using PruebaTecnica.Api.Src.Core.Domain.Entities;
using PruebaTecnica.Api.Src.Core.DTOs.Transport;

namespace PruebaTecnica.Api.Src.Core.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieEntity, MovieDto>().ReverseMap();
        }
    }
}
