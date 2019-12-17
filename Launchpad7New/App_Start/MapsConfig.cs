using AutoMapper;
using Launchpad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Launchpad7New.Models;


namespace Launchpad7New.App_Start
{
    public class MapsConfig
    {
        public static void RegisterMaps()
        {
            //Mapper.Configuration.CreateMapper<Item, ItemViewModel>();
            //Mapper.CreateMap<JumpStartPakistan.Domain.Entities.User, JumpStartPakistan.Web.Areas.Admin.Models.User>();
            //Mapper.CreateMap<JumpStartPakistan.Web.Areas.Admin.Models.User, JumpStartPakistan.Domain.Entities.User>();
            //Mapper.Initialize(
            //config =>
            //{
            //    config.CreateMap<ApplicationUser, RegisterViewModel>()
            //        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            //});
            //Mapper.Configuration.CreateMapper<Launchpad7New.Models.ApplicationUser, Launchpad7New.Models.RegisterViewModel>();
            //Mapper.Configuration.CreateMapper<Launchpad7New.Models.RegisterViewModel, Launchpad7New.Models.ApplicationUser>();
        }
    }
}