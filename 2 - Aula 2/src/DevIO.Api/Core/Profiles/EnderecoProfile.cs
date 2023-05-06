using AutoMapper;
using DevIO.Business.DataTransferObjects;
using DevIO.Business.Models;

namespace DevIO.Api.Core.Profiles
{
    public abstract class EnderecoProfile : Profile
    {
        protected EnderecoProfile()
        {
            CreateMap<Endereco, EnderecoDTO>(MemberList.None).ReverseMap();
        }
    }
}
