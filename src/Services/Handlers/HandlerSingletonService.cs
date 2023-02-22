namespace src.Services.Handlers;

public class HandlerSingletonService
{
    private ISingletonService _service;

    public HandlerSingletonService(ISingletonService service)
    {
        _service = service;
    }

    public Guid GetId() => _service.Identificator;
}
