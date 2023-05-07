using AutoMapper;
using DevIO.Business.DataTransferObjects;
using DevIO.Business.Models;

namespace DevIO.Api.Core.Profiles
{
    public abstract class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Fornecedor, FornecedorDTO>(MemberList.None).ReverseMap();

            CreateMap<Endereco, EnderecoDTO>(MemberList.None).ReverseMap();

            CreateMap<Produto, ProdutoDTO>(MemberList.None)
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
            CreateMap<ProdutoDTO, Produto>(MemberList.None);
            CreateMap<ProdutoImagemDTO, Produto>(MemberList.None).ReverseMap();
        }
    }
}