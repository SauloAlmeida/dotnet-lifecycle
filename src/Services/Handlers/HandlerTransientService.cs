namespace src.Services.Handlers;

public class HandlerTransientService
{
    private ITransientService _service;

    public HandlerTransientService(ITransientService service)
    {
        _service = service;
    }

    public Guid GetId() => _service.Identificator;
}
