using DevIO.Business.Models;
using System.Linq.Expressions;

namespace DevIO.Business.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
        Task<T> ObterPorIdAsync(Guid id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task AdicionarAsync(T entity);
        Task AtualizarAsync(T entity);
        Task RemoverAsync(Guid id);
        Task SaveChangesAsync();
    }
}