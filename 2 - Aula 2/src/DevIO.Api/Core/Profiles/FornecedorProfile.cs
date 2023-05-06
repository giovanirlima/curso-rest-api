using AutoMapper;
using DevIO.Business.DataTransferObjects;
using DevIO.Business.Models;

namespace DevIO.Api.Core.Profiles
{
    public abstract class FornecedorProfile : Profile
    {
        protected FornecedorProfile()
        {
            CreateMap<Fornecedor, FornecedorDTO>(MemberList.None).ReverseMap();
        }
    }
}