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

        // Utilize o código abaixo caso no DTo tenha um campo com um nome diferente do que há no modelo;
        // Por exemplo, nesse caso abaixo ReadCinemaDto possuia o campo ReadEnderecoDto, mas o modelo Cinema
        // não possui esse campo, possui Endereco. Por tanto, precisamos mapear o campo ReadEnderecoDto com 
        // campo Endereco. 
        // CreateMap<Cinema, ReadCinemaDto>().ForMember(cinemaDto => cinemaDto.ReadEnderecoDto,
        // opt=> opt.MapFrom(cinema => cinema.Endereco);
        // );

        CreateMap<UpdateCinemaDto, Cinema>();
    }
}
