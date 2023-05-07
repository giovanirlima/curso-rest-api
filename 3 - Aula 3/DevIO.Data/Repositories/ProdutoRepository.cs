using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Context context) : base(context) { }

        public async Task<Produto> ObterProdutoFornecedorAsync(Guid id) =>
            await Context.Produtos.AsNoTracking()
                    .Include(f => f.Fornecedor)
                    .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedoresAsync() =>
            await Context.Produtos.AsNoTracking()
                    .Include(f => f.Fornecedor)
                    .OrderBy(p => p.Nome)
                    .ToListAsync();

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedorAsync(Guid fornecedorId) =>
            await Buscar(p => p.FornecedorId == fornecedorId);
    }
}