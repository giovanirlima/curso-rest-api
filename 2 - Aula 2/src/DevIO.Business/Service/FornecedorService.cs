using AutoMapper;
using DevIO.Business.DataTransferObjects;
using DevIO.Business.Interfaces;

namespace DevIO.Business.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FornecedorDTO>> ObterTodosAsync()
        {
            var fornecedores = await _repository.ObterTodosAsync();

            if (fornecedores.ToList().Count == 0)
                return Enumerable.Empty<FornecedorDTO>();

            return _mapper.Map<IEnumerable<FornecedorDTO>>(fornecedores);
        }

        public async Task<FornecedorDTO> ObterPorIdAsync(Guid id)
        {
            var fornecedor = await _repository.ObterPorIdAsync(id);

            if (fornecedor is null)
                return null;

            return _mapper.Map<FornecedorDTO>(fornecedor);
        }
    }
}