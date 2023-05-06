using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
    }
}