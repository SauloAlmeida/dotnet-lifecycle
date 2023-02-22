namespace src.Services;

public interface IScopedService : ICommonService
{
}

public class ScopedService : IScopedService
{
    public Guid Identificator { get; init; } = Guid.NewGuid();
}