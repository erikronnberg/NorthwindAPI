using AutoMapper;
using NorthwindAPI.Data.Entities;
using NorthwindAPI.Models;

namespace NorthwindAPI.Data
{
    public class NorthwindMappingProfile : Profile
    {
        public NorthwindMappingProfile()
        {
            CreateMap<Supplier, SupplierModel>().ReverseMap();
            CreateMap<Product, ProductModel>();
        }
    }
}
