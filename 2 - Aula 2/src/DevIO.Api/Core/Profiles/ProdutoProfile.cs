using AutoMapper;
using DevIO.Business.DataTransferObjects;
using DevIO.Business.Models;

namespace DevIO.Api.Core.Profiles
{
    public abstract class ProdutoProfile : Profile
    {
        protected ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDTO>(MemberList.None).ReverseMap();
        }
    }
}