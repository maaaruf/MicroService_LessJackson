using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers;

[Route("api/c/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICommandRepo _repository;

    public PlatformsController(ICommandRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult TestInboundConnection()
    {
        Console.WriteLine("--> Inbound POST # Command Service");
        return Ok("Inbound test of from Platforms Controller");
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("--> Getting Platforms from Command Service");
        var platformItems = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
    }
}