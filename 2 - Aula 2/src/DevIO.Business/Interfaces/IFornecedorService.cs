using DevIO.Business.DataTransferObjects;

namespace DevIO.Business.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorDTO>> ObterTodosAsync();
        Task<FornecedorDTO> ObterPorIdAsync(Guid id);
    }
}