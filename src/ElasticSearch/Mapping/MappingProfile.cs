using AutoMapper;
using Core.Models;
using ElasticSearch.DTO;

namespace ElasticSearch.Mapping
{
    public class MappingProfile : Profile
    {
        private string PhotoUrl = "https://res.cloudinary.com/kamranmirze1/image/upload/v1585144661/";

        public MappingProfile()
        {
            CreateMap<ProductSetDto, Product>();

            CreateMap<Product, ProductGetDto>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(src => PhotoUrl + src.Photo));

            CreateMap<ProductEditDto, Product>();
        }
    }
}
