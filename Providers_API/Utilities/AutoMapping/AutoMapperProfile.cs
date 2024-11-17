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
            #endregion

            #region Provider
            CreateMap<Provider, VMProvider>().ReverseMap();
            #endregion
        }

    }
}
