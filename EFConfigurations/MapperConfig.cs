using AutoMapper;
using PizzaPlaceSalesAPI.Dto;
using PizzaPlaceSalesAPI.Models;
using System.Drawing;
using System.Reflection.Metadata;

namespace PizzaPlaceSalesAPI.EFConfigurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Order, Order_Dto>().ReverseMap();
            CreateMap<Order_Detail, Order_Detail_Dto>().ReverseMap();
            CreateMap<Pizza, Pizza_Dto>().ReverseMap();
            CreateMap<Pizza_Type, Pizza_Type_Dto>().ReverseMap();
        }
    }
}
