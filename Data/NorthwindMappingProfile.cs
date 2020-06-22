using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NorthwindAPI.Data.Entities;
using NorthwindAPI.Models;

namespace NorthwindAPI.Data
{
    public class NorthwindMappingProfile : Profile
    {
        public NorthwindMappingProfile()
        {
            CreateMap<Supplier, SupplierModel>();
            CreateMap<Product, ProductModel>();
        }
    }
}
