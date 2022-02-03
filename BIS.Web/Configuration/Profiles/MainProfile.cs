using AutoMapper;
using System;
using BIS.Model.DataModels;
using BIS.ViewModels.VM;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BIS.Web.Configuration.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Donor, DonorVm>()
                .ForMember (dest => dest.BloodGroups, x => x.MapFrom (src => src.DonorBloods.Select (y => y.BloodGroup)));
            CreateMap<AddOrUpdateDonorVm, Donor>();
            CreateMap<DonorVm, AddOrUpdateDonorVm>();
            CreateMap<BloodGroup, BloodGroupVm>()
                .ForMember (dest => dest.Donors, x => x.MapFrom (src => src.DonorBloods.Select (s => s.Donor)));

            CreateMap<AddOrUpdateBloodGroupVm, BloodGroup>();
            CreateMap<BloodGroupVm, AddOrUpdateBloodGroupVm>();
            CreateMap<BloodGroupVm, SelectListItem> ()
                .ForMember (x => x.Text, y => y.MapFrom (z => z.Type))
                .ForMember (x => x.Value, y => y.MapFrom (z => z.Id));

            CreateMap<RegisterNewUserVm, User>()
                .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
                .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now));
        }
    }
}