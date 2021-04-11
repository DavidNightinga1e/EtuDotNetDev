using System.Threading.Tasks;
using AutoMapper;
using CarDatabase.Business.Contracts;
using CarDatabase.Domain.Models;
using Client.DTO.Read;
using Client.Requests.Create;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarDatabase.WebAPI.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnerController : ControllerBase
    {
        private ILogger<OwnerController> Logger { get; }
        private ICreateOwnerService CreateOwnerService { get; }
        private IGetOwnerService GetOwnerService { get; }

        private IMapper Mapper { get; }

        public OwnerController(ILogger<OwnerController> logger, IMapper mapper, ICreateOwnerService createOwnerService,
            IGetOwnerService getOwnerService)
        {
            Logger = logger;
            Mapper = mapper;
            CreateOwnerService = createOwnerService;
            GetOwnerService = getOwnerService;
        }

        [HttpPut]
        [Route("put")]
        public async Task<OwnerDTO> PutAsync(OwnerCreateDTO ownerCreateDto)
        {
            Logger.LogTrace($"{nameof(PutAsync)} call");

            var result = await CreateOwnerService.CreateOwner(Mapper.Map<OwnerUpdateModel>(ownerCreateDto));

            return Mapper.Map<OwnerDTO>(result);
        }
        
        [HttpGet]
        [Route("{ownerId}")]
        public async Task<OwnerDTO> GetAsync(int ownerId)
        {
            Logger.LogTrace($"{nameof(GetAsync)} call for {ownerId}");
            
            var result = await GetOwnerService.GetOwner(new OwnerIdentityModel(ownerId));
            
            return Mapper.Map<OwnerDTO>(result);
        }
    }
}