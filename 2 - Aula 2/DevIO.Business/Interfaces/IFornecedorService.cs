using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<bool> AdicionarAsync(Fornecedor fornecedor);
        Task<bool> AtualizarAsync(Fornecedor fornecedor);
        Task<bool> RemoverAsync(Guid id);

        Task AtualizarEnderecoAsync(Endereco endereco);
    }
}