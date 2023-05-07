using System.ComponentModel.DataAnnotations;

namespace DevIO.Business.DataTransferObjects
{
    public class FornecedorDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public int TipoFornecedor { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<ProdutoDTO> Produtos { get; set; }
    }
}