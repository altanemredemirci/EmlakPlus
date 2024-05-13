using AutoMapper;
using EmlakPlus.BLL.DTOs.ProductDTO;
using EmlakPlus.BLL.DTOs.ProductTypeDTO;
using EmlakPlus.BLL.DTOs.SliderDTO;
using EmlakPlus.BLL.DTOs.WhoWeAreDTO;
using EmlakPlus.Entity;

namespace EmlakPlus.WEBUI.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<ProductType, ResultProductTypeDTO>().ReverseMap();
            CreateMap<Slider, ResultSliderDTO>().ReverseMap();
            CreateMap<WhoWeAre, ResultWhoWeAreDTO>().ReverseMap();
        }
    }
}
