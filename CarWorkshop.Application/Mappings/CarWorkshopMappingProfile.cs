using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.UpdateCarWorkshop;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mappings
{
    public class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));

            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(e => e.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(e => e.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(e => e.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(e => e.IsEditable, opt => opt.MapFrom(src => user != null &&
                                            (src.CreatedById == user.Id || user.IsInRole("Moderator"))));

            CreateMap<CarWorkshopDto, EditCarWorkshopCommand>();
        }
    }
}
