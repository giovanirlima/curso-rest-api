using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(Context context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId) =>
            await Context.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
    }
}