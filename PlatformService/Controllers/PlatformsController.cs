using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IMapper _mapper;
        public IPlatformRepo _platformRepository { get; }
        public PlatformsController(IPlatformRepo platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms...");

            var platformItems = _platformRepository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            Console.WriteLine("--> Getting Platform by Id...");

            var platformItem = _platformRepository.GetPlatformById(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            Console.WriteLine("--> Creating Platform...");

            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _platformRepository.CreatePlatform(platformModel);
            _platformRepository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlatform(int id, PlatformUpdateDto platformUpdateDto)
        {
            Console.WriteLine("--> Updating Platform...");

            var platformModelFromRepo = _platformRepository.GetPlatformById(id);
            if (platformModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(platformUpdateDto, platformModelFromRepo);
            _platformRepository.UpdatePlatform(platformModelFromRepo);
            _platformRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlatform(int id)
        {
            Console.WriteLine("--> Deleting Platform...");

            var platformModelFromRepo = _platformRepository.GetPlatformById(id);
            if (platformModelFromRepo == null)
            {
                return NotFound();
            }
            _platformRepository.DeletePlatform(platformModelFromRepo);
            _platformRepository.SaveChanges();
            return NoContent();
        }
    }
}