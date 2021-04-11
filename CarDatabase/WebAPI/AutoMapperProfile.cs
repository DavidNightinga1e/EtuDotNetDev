using AutoMapper;
using CarDatabase.Domain.Models;
using Client.DTO.Read;
using Client.Requests.Create;

namespace CarDatabase.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataAccess.Entities.Car, Domain.Car>();
            CreateMap<DataAccess.Entities.CarOwner, Domain.Owner>();
            
            CreateMap<Domain.Car, CarDTO>();
            CreateMap<Domain.Owner, OwnerDTO>();
            CreateMap<CarCreateDTO, CarUpdateModel>();
            CreateMap<OwnerCreateDTO, OwnerUpdateModel>();
        }
    }
}