using DesafioHortmart.Core.DomainObjects;

namespace DesafioHortmart.Core.Data
{
    internal interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        public IUnityOfWork UnityOfWork { get; set; }
    }
}
