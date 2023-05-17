using System;
using AutoMapper;
using FilmesAPI.Data.DTO.CinemaDto;
using FilmesAPI.Models;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>();
        CreateMap<UpdateCinemaDto, Cinema>();
    }
}
