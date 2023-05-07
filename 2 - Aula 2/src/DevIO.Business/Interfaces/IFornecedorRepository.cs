using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEnderecoAsync(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEnderecoAsync(Guid id);
    }
}