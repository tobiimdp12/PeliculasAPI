using AutoMapper;
using PeliculasAPI.DTOs;
using PeliculasAPI.Models;

namespace PeliculasAPI.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterDTO>();
            CreateMap<CharacterCreationDTO,Character >();

            CreateMap<Movies, MovieDTO>();
            CreateMap<MovieCreationDTO, Movies>();

            CreateMap<MovieCreationDTO, Movies>();

        }
       
       
    }
}
