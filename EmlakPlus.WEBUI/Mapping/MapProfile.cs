using AutoMapper;
using EmlakPlus.BLL.DTOs.AgencyDTO;
using EmlakPlus.BLL.DTOs.ClientDTO;
using EmlakPlus.BLL.DTOs.ContactDTO;
using EmlakPlus.BLL.DTOs.ProductDetailDTO;
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
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<ProductType, ResultProductTypeDTO>().ReverseMap();
            CreateMap<ProductType, CreateProductTypeDTO>().ReverseMap();
            CreateMap<ProductType, UpdateProductTypeDTO>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDTO>().ReverseMap();


            CreateMap<Slider, ResultSliderDTO>().ReverseMap();
            CreateMap<Slider, UpdateSliderDTO>().ReverseMap();
            CreateMap<Slider, CreateSliderDTO>().ReverseMap();

            CreateMap<WhoWeAre, ResultWhoWeAreDTO>().ReverseMap();

            CreateMap<Agency, ResultAgencyDTO>().ReverseMap();
            CreateMap<Agency, CreateAgencyDTO>().ReverseMap();
            CreateMap<Agency, UpdateAgencyDTO>().ReverseMap();

            CreateMap<Client, ResultClientDTO>().ReverseMap();
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
        }
    }
}
