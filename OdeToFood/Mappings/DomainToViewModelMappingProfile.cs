using AutoMapper;
using OdeToFood.Models;
using OdeToFood.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMapping"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Restaurant, RestaurantListViewModel>()
                .ForSourceMember(restModel => restModel.Reviews, map => map.Ignore());
            //Mapper.CreateMap<UserProfile, EditUserRolesViewModel>()
            //    .ForSourceMember(restModel => restModel.Reviews, map => map.Ignore());
        }
    }
}