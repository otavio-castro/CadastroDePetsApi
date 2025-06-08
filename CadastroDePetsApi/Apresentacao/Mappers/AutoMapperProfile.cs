using AutoMapper;
using CadastroDePetsApi.Apresentacao.DTOs;
using CadastroDePetsApi.Persistencia.Entidades;

namespace CadastroDePetsApi.Apresentacao.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Animal, AnimalDto>()
          .ForMember(dest => dest.AnimalId, opt => opt.MapFrom(src => src.AnimalId))
          .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
          .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => src.Idade))
          .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
          .ForMember(dest => dest.Raca, opt => opt.MapFrom(src => src.Raca));

        CreateMap<Proprietario, ProprietarioDto>()
          .ForMember(dest => dest.ProprietarioId, opt => opt.MapFrom(src => src.ProprietarioId))
          .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
          .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
          .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone));
    }
}