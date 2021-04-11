using System;
using System.Threading.Tasks;
using AutoMapper;
using CarDatabase.DataAccess.Context;
using CarDatabase.DataAccess.Contracts;
using CarDatabase.Domain;
using CarDatabase.Domain.Contracts;
using CarDatabase.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDatabase.DataAccess.Implementation
{
    public class OwnerDataAccess : IOwnerDataAccess
    {
        private CarDatabaseContext Context { get; }
        private IMapper Mapper { get; }

        public OwnerDataAccess(CarDatabaseContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<Owner> GetOwner(IOwnerId ownerId)
        {
            if (ownerId == null)
                throw new ArgumentNullException(nameof(ownerId));

            var entity = await Context.Owners.FirstOrDefaultAsync(t => t.Id == ownerId.OwnerId);

            return Mapper.Map<Owner>(entity);
        }

        public async Task<Owner> CreateOwner(OwnerUpdateModel ownerUpdateModel)
        {
            if (ownerUpdateModel == null)
                throw new ArgumentNullException(nameof(ownerUpdateModel));

            var entityEntry = await Context.Owners.AddAsync(Mapper.Map<Entities.CarOwner>(ownerUpdateModel));

            await Context.SaveChangesAsync();

            return Mapper.Map<Owner>(entityEntry.Entity);
        }
    }
}