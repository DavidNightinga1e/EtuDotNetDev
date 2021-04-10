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
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private ILogger<CarController> Logger { get; }
        private ICreateCarService CreateCarService { get; }
        private IGetCarService GetCarService { get; }

        private IMapper Mapper { get; }

        public CarController(ILogger<CarController> logger, IMapper mapper, ICreateCarService createCarService,
            IGetCarService getCarService)
        {
            Logger = logger;
            Mapper = mapper;
            CreateCarService = createCarService;
            GetCarService = getCarService;
        }

        [HttpPut]
        [Route("")]
        public async Task<CarDTO> PutAsync(CarCreateDTO carCreateDto)
        {
            Logger.LogTrace($"{nameof(PutAsync)} call");

            var result = await CreateCarService.CreateCar(Mapper.Map<CarUpdateModel>(carCreateDto));

            return Mapper.Map<CarDTO>(result);
        }
        
        [HttpGet]
        [Route("{carId}")]
        public async Task<CarDTO> GetAsync(ulong carId)
        {
            Logger.LogTrace($"{nameof(GetAsync)} call for {carId}");
            
            var result = await GetCarService.GetCar(new CarIdentityModel(carId));
            
            return Mapper.Map<CarDTO>(result);
        }
    }
}