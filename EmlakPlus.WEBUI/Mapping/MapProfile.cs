using AutoMapper;
using EmlakPlus.BLL.DTOs.AgencyDTO;
using EmlakPlus.BLL.DTOs.ClientDTO;
using EmlakPlus.BLL.DTOs.ContactDTO;
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
            CreateMap<ProductType, CreateProductTypeDTO>().ReverseMap();
            CreateMap<ProductType, UpdateProductTypeDTO>().ReverseMap();
            CreateMap<Slider, ResultSliderDTO>().ReverseMap();
            CreateMap<WhoWeAre, ResultWhoWeAreDTO>().ReverseMap();
            CreateMap<Agency, ResultAgencyDTO>().ReverseMap();
            CreateMap<Client, ResultClientDTO>().ReverseMap();
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
        }
    }
}
