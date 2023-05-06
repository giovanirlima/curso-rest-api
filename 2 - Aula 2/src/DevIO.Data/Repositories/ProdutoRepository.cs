using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Context context) : base(context) { }

        public async Task<Produto> ObterProdutoFornecedor(Guid id) =>
            await Context.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores() =>
            await Context.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId) =>
            await Buscar(p => p.FornecedorId == fornecedorId);
    }
}
