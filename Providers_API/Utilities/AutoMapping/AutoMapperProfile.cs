using AutoMapper;
using Providers_API.Models;
using Providers_API.ViewModels;

namespace Providers_API.Utilities.AutoMapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            #region User & RegisterUser
            CreateMap<User, VMUser>().ReverseMap();
            CreateMap<User, RegisterVMUser>().ReverseMap();
            CreateMap<VMUser, RegisterVMUser>().ReverseMap();
            #endregion 

            #region Active
            CreateMap<Active, VMActive>().ReverseMap();

            CreateMap<Active, MinimalVMResponse>()
                .ForMember(dest => dest.UniqueId, opt => opt.MapFrom(org => org.ActiveId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(org => org.ProductCode))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(org => org.ActiveName));

            #endregion

            #region Activity
            CreateMap<Activity, VMActivity>().ReverseMap();
            #endregion

            #region Commentary
            CreateMap<Commentary, VMCommentary>().ReverseMap();
            #endregion

            #region Contact
            CreateMap<Contact, VMContact>().ReverseMap();
            #endregion

            #region Post
            CreateMap<Post, VMPost>().ReverseMap();

            CreateMap<Post, MinimalVMResponse>()
                .ForMember(dest => dest.UniqueId, opt => opt.MapFrom(org => org.PostId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(org => org.Description))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(org => org.Title));
            #endregion

            #region Provider
            CreateMap<Provider, VMProvider>()
                .ForMember(dest => dest.Contacts, opt => opt.MapFrom(org => org.Contacts))
                .ForMember(dest => dest.Actives, opt => opt.MapFrom(org => org.Actives))
                .ForMember(dest => dest.Activities, opt => opt.MapFrom(org => org.Activities))
                .ForMember(dest => dest.User, opt => opt.MapFrom(org => org.User))
                .ForMember(dest => dest.Posts, opt => opt.MapFrom(org => org.Posts));

            CreateMap<VMProvider, Provider>()
                .ForMember(dest => dest.Contacts, opt => opt.Ignore())
                .ForMember(dest => dest.Activities, opt => opt.Ignore())
                .ForMember(dest => dest.Actives, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(org => org.User.UserId));

            CreateMap<Provider, MinimalVMResponse>()
                .ForMember(dest => dest.UniqueId, opt => opt.MapFrom(org => org.ProviderId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(org => org.User.Description))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(org => org.User.Name));
            #endregion
        }

    }
}
