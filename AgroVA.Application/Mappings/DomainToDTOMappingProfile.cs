using AgroVA.Application.DTOs;
using AgroVA.Domain.Entities;
using AutoMapper;

namespace AgroVA.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Annotation, AnnotationDTO>().ReverseMap();
            CreateMap<Farmer, FarmerDTO>().ReverseMap();
            CreateMap<Harvest, HarvestDTO>().ReverseMap();
            CreateMap<HuskPrice, HuskPriceDTO>().ReverseMap();
            CreateMap<Load, LoadDTO>().ReverseMap();
            CreateMap<Promissory, PromissoryDTO>().ReverseMap();
            CreateMap<Receipt, ReceiptDTO>().ReverseMap();
            CreateMap<Rent, RentDTO>().ReverseMap();

        }
    }
}
