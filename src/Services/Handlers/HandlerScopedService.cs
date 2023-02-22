namespace src.Services.Handlers;

public class HandlerScopedService
{
    private IScopedService _service;

    public HandlerScopedService(IScopedService service)
    {
        _service = service;
    }

    public Guid GetId() => _service.Identificator;
}
