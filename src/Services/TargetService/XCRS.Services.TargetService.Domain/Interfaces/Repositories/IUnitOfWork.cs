namespace XCRS.Services.TargetService.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ITargetsRepository TargetRepository { get; }

        Task CompleteAsync();
    }
}
