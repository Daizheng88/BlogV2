using AutoMapper;
using Blog.Application.Core.User.Commands;
using Blog.Contract.Infrastructure;
using Blog.Contract.Infrastructure.Extensions;
using Blog.Core.User.Dtos;
using System;

namespace Blog.Application.Core.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // 注册指令映射
            this.CreateMap<RegisterUserCommand, UserDto>()
                .ForMember(t => t.Id, s => s.MapFrom(i => Guid.NewGuid()))
                .ForMember(t => t.Creator, s => s.MapFrom(i => Guid.Empty))
                .ForMember(t => t.CreateTime, s => s.MapFrom(i => DateTime.Now.Localization()))
                .ForMember(t => t.IsDeleted, s => s.MapFrom(i => DbBoolean.False))
                .ForMember(t => t.EMail, s => s.MapFrom(i => i.EMail))
                .ForMember(t => t.Password, s => s.MapFrom(i => Encrypt.Md5(i.Password, "2020/05/05")))
                .ForMember(t => t.Name, s => s.MapFrom(i => i.Name))
                ;

            // 注册后指令映射
            this.CreateMap<RegisterUserCommand, RegisteredUserCommand>()
                .ForMember(t => t.EMail, s => s.MapFrom(i => i.EMail))
                .ForMember(t => t.Name, s => s.MapFrom(i => i.Name))
                ;

            // 更新指令映射
            this.CreateMap<UpdateUserCommand, UserDto>()
                .ForMember(t => t.Name, s => s.MapFrom(i => i.Name))
                .ForMember(t => t.Modifier, s => s.MapFrom(i => Guid.Empty))
                .ForMember(t => t.ModifyTime, s => s.MapFrom(i => DateTime.Now.Localization()))
                ;
        }
    }
}
