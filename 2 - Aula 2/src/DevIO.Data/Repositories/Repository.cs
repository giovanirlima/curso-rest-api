using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.ContextDB;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevIO.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly Context Context;
        protected readonly DbSet<T> DbSet;

        protected Repository(Context context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate) =>
            await DbSet.AsNoTracking().Where(predicate).ToListAsync();

        public virtual async Task<T> ObterPorIdAsync(Guid id) =>
            await DbSet.FindAsync(id);

        public virtual async Task<IEnumerable<T>> ObterTodosAsync() =>
            await DbSet.ToListAsync();

        public virtual async Task AdicionarAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public virtual async Task AtualizarAsync(T entity)
        {
            DbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task RemoverAsync(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync() =>
            await Context.SaveChangesAsync();

        public void Dispose() =>
            Context.Dispose();
    }
}