using AutoMapper;
using DevIO.Business.DataTransferObjects;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [Route("api/produtos")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(INotificador notificador,
                                  IProdutoRepository produtoRepository,
                                  IProdutoService produtoService,
                                  IMapper mapper) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterProdutosFornecedoresAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> ObterPorId(Guid id)
        {
            var produtoDTO = await ObterProduto(id);

            if (produtoDTO == null) return NotFound();

            return produtoDTO;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Adicionar(ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imagemNome = Guid.NewGuid() + "_" + produtoDTO.Imagem;
            if (!UploadArquivo(produtoDTO.ImagemUpload, imagemNome))
            {
                return CustomResponse(produtoDTO);
            }

            produtoDTO.Imagem = imagemNome;
            await _produtoService.AdicionarAsync(_mapper.Map<Produto>(produtoDTO));

            return CustomResponse(produtoDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var produtoAtualizacao = await ObterProduto(id);
            produtoDTO.Imagem = produtoAtualizacao.Imagem;
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (produtoDTO.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + produtoDTO.Imagem;
                if (!UploadArquivo(produtoDTO.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                produtoAtualizacao.Imagem = imagemNome;
            }

            produtoAtualizacao.Nome = produtoDTO.Nome;
            produtoAtualizacao.Descricao = produtoDTO.Descricao;
            produtoAtualizacao.Valor = produtoDTO.Valor;
            produtoAtualizacao.Ativo = produtoDTO.Ativo;

            await _produtoService.AtualizarAsync(_mapper.Map<Produto>(produtoAtualizacao));

            return CustomResponse(produtoDTO);
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<ProdutoDTO>> AdicionarAlternativo(ProdutoImagemDTO produtoImagemDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivoAlternativo(produtoImagemDTO.ImagemUpload, imgPrefixo))
            {
                return CustomResponse(ModelState);
            }

            produtoImagemDTO.Imagem = imgPrefixo + produtoImagemDTO.ImagemUpload.FileName;
            await _produtoService.AdicionarAsync(_mapper.Map<Produto>(produtoImagemDTO));

            return CustomResponse(produtoImagemDTO);
        }


        [RequestSizeLimit(40000000)]
        //[DisableRequestSizeLimit]
        [HttpPost("imagem")]
        public ActionResult AdicionarImagem(IFormFile file) =>
            Ok(file);


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> Excluir(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null) return NotFound();

            await _produtoService.RemoverAsync(id);

            return CustomResponse(produto);
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app/demo-webapi/src/assets", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }

        private async Task<bool> UploadArquivoAlternativo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app/demo-webapi/src/assets", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

        private async Task<ProdutoDTO> ObterProduto(Guid id) =>
            _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterProdutoFornecedorAsync(id));
    }
}