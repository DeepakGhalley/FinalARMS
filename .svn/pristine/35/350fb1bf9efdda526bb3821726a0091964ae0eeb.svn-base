using AutoMapper;
using CORE_BOL;
using CORE_BOL.Entities;

namespace ARMS 
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MstUser, UserDTO>()
            //CreateMap<UserViewModel, UserDTO>();
            //CreateMap<TblMstUser, UserViewModel>();
            //CreateMap<UserDTO, UserViewModel>()
            //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            //     .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            // .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ReverseMap()
             ;

            //CreateMap<UserViewModel, TblMstUser>();
            // CreateMap<TblMstUser, UsersViewModel>();


        }
    }
}
