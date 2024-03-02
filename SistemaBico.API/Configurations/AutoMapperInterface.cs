using AutoMapper;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Generics.Extensions;
using SistemaBico.API.Dtos;

namespace SistemaBico.API.Configurations
{
    public class AutoMapperInterface : Profile
    {
        private string IMAGEM_PADRAO = "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";
        public AutoMapperInterface()
        {
            _ = CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.TipoProduto,
                    opt => opt.MapFrom(src => src.TipoProduto != null ? src.TipoProduto.GetDescription() : null))
                .ForMember(dest => dest.FotoBase64,
                    opt => opt.MapFrom(src => string.IsNullOrEmpty(src.FotoBase64) ? IMAGEM_PADRAO : src.FotoBase64))
                .ForMember(dest => dest.DataCadastro,
                    opt => opt.MapFrom(src => src.Created.ToString("dd/MM/yyyy")));
        }
    }
}
