namespace src.Services;

public interface ITransientService : ICommonService
{
}

public class TransientService : ITransientService
{
    public Guid Identificator { get; init; } = Guid.NewGuid();
}
