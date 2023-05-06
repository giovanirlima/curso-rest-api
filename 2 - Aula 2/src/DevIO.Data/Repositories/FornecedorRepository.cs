using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(Context context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id) =>
            await Context.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id) =>
            await Context.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
    }
}