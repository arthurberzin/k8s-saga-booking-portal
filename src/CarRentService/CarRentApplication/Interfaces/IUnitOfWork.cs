namespace CarRent.Application.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }
        ILocationRepository Locations { get; }
        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
