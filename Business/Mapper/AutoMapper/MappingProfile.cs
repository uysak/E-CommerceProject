using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.CargoFirmDTOs;
using Entity.DTOs.CategoryDTOs;
using Entity.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryForUpdateDto, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<CategoryForCreateDto, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()).ForMember(dest=> dest.CategoryImg, opt=> opt.Ignore()).ReverseMap();

            CreateMap<CargoFirmForCreateDto, CargoFirm>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<CargoFirmForUpdateDto, CargoFirm>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();


            CreateMap<ProductForCreateDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();




        }
    }



}


