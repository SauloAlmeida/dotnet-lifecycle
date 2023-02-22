using Microsoft.AspNetCore.Mvc;
using src.Services;
using src.Services.Handlers;

namespace DotnetLifeCycle.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LifeCycleController : ControllerBase
{
    private readonly IScopedService _scopedService;
    private readonly HandlerScopedService _handlerScoped;

    private readonly ITransientService _transientService;
    private readonly HandlerTransientService _handlerTransient;

    private readonly ISingletonService _singletonService;
    private readonly HandlerSingletonService _handlerSingleton;

    public LifeCycleController(IScopedService scopedService,
                               HandlerScopedService handlerScoped,
                               ITransientService transientService,
                               HandlerTransientService handlerTransient,
                               ISingletonService singletonService,
                               HandlerSingletonService handlerSingleton)
    {
        _scopedService = scopedService;
        _handlerScoped =  handlerScoped;

        _transientService = transientService;
        _handlerTransient = handlerTransient;

        _singletonService = singletonService;
        _handlerSingleton = handlerSingleton;
    }

    [HttpGet("scoped")]
    public IActionResult GetScoped() 
        => Ok(new ResponseOutput(_scopedService.Identificator, 
                                 _handlerScoped.GetId(),
                                 "The first instance that is created will be shared with any other references that use it until the end of the request."));

    [HttpGet("transient")]
    public IActionResult GetTransient()
        => Ok(new ResponseOutput(_transientService.Identificator, 
                                 _handlerTransient.GetId(),
                                 "For each request and references every instance is created."));

    [HttpGet("singleton")]
    public IActionResult GetSingleton()
        => Ok(new ResponseOutput(_singletonService.Identificator, 
                                 _handlerSingleton.GetId(),
                                 "The first intance that is created will be shared with any other references and requests that use it until the end of the application."));

    public class ResponseOutput
    {
        public ResponseOutput(Guid id, Guid handlerId, string info)
        {
           Id = id;
           HandlerId = handlerId; 
           Info = info;
        }

        public Guid Id { get; private set; }
        public Guid HandlerId { get; private set; }
        public string Info {get; private set; }
    }
}
