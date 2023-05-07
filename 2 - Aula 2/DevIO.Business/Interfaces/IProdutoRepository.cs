using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedorAsync(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedoresAsync();
        Task<Produto> ObterProdutoFornecedorAsync(Guid id);
    }
}