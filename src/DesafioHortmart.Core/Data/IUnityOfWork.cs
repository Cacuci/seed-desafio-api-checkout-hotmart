namespace DesafioHortmart.Core.Data
{
    public interface IUnityOfWork
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken);
    }
}
