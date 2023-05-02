namespace Hotel.Application.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        IPeriodRepository Periods { get; }
        IHotelRepository Hotels { get; }
        IHotelImageRepository HotelImages { get; }
        IOccupateDateRepository HotelOccupateDates { get; }

        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
