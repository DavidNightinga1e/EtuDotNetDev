using AutoMapper;

namespace CarDatabase.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataAccess.Entities.Car, Domain.Car>();
            CreateMap<DataAccess.Entities.Owner, Domain.Owner>();
            
        }
    }
}