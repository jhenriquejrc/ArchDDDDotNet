using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.MVC.ViewModels;
using AutoMapper;

namespace ArquiteturaDDD.MVC.AutoMapper
{
    public class ViewToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewToViewModelMappings";
            }
        }

        public ViewToViewModelMappingProfile()
        {
            CreateMap<ClientViewModel, Client>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}