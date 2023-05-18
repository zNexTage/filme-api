using System;
using AutoMapper;
using FilmesAPI.Data.DTO.SessaoDto;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>();
    }
}
