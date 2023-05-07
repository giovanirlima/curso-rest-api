using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(Context context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEnderecoAsync(Guid id) =>
            await Context.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Fornecedor> ObterFornecedorProdutosEnderecoAsync(Guid id) =>
            await Context.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
    }
}