namespace src.Services;

public interface ISingletonService : ICommonService
{
}


public class SingletonService : ISingletonService
{
    public Guid Identificator { get; init; } = Guid.NewGuid();
}
