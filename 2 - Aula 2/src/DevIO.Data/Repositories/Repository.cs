using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.ContextDb;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevIO.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly Context Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(Context context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate) =>
            await DbSet.AsNoTracking().Where(predicate).ToListAsync();

        public virtual async Task<TEntity> ObterPorIdAsync(Guid id) =>
            await DbSet.FindAsync(id);

        public virtual async Task<List<TEntity>> ObterTodos() =>
            await DbSet.ToListAsync();

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChangesAsync();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync() =>
            await Context.SaveChangesAsync();

        public void Dispose() =>
            Context?.Dispose();
    }
}