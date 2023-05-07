using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(Context context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedorAsync(Guid fornecedorId) =>
            await Context.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
    }
}