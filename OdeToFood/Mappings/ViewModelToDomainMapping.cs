using AutoMapper;
using OdeToFood.Models;
using OdeToFood.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMapping"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<RestaurantListViewModel, Restaurant>()
                .ForSourceMember(restModel => restModel.ReviewsCount, map => map.Ignore());

        }
    }
}