using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Controllers;
using PeliculasAPI.Data;
using PeliculasAPI.DTOs;
using PeliculasAPI.Models;
using PeliculasAPI.Repositories;
using PeliculasAPI.Services;
using PeliculasAPI.Utils;
using System;
using FluentAssertions;
using Xunit;

namespace PeliculasUnitTesting
{
    public class CharactersTesting
    {
        private readonly CharactersController _characterController;
        private readonly ICharacterService _characterService;
        private readonly IMovieService _movieService;
        private readonly ICharacterRepository _characterReepository;
        private readonly IMovieRepository _movieReepository;
        private readonly IMapper mapper;
        private readonly DataContext data;

        public CharactersTesting()
        {
            var dbOption = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(@"Data Source=DESKTOP-FBL8M17\\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True")
            .Options;

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            data = new DataContext(dbOption);
            
            mapper = new Mapper(mapperConfig);

            _characterReepository = new CharacterRepository(data);
            _movieReepository = new MovieRepository(data);

            _characterService = new CharacterService(_characterReepository, mapper);
            _movieService = new MovieService(_movieReepository, mapper);

            _characterController = new CharactersController(_characterService, _movieService);
        }

        [Fact]//Fact: pruebas a ejecutar
        public void Get_Characters()
        {
            var result =  _characterController.GetCharacters();

            Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(result);
        }

        [Fact]//Fact: pruebas a ejecutar
        public void Get_CharacterId()
        {
            int id = 1;//ejemplo

            //accion
            //(OkObjectResult): para obtener la informacion
            var result = (OkObjectResult)_characterController.GetCharacter(id);

            //resultado
            var character = Assert.IsType<Character>(result?.Value);
            Assert.True(character != null);//siempre tiene que haber data
            Assert.Equal(character?.Id, id);
        }

        [Fact]//Fact: pruebas a ejecutar
        public void CheckCharacterIdNotFound()
        {
            int id = 1242;//ejemplo


            //accion
            var result = _characterController.GetCharacter(id);


            //Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]//Fact: pruebas a ejecutar
        public void CheckInputCreateCharacter()
        {

            CharacterCreationDTO character = new CharacterCreationDTO
            {
                Name = "prueba2",
                Image = "fs",
                Age = 2,
                Weight = 2,
                History = "sfsfssfdsd"

            }; 

            //accion
            var result = _characterController.PostCharacter(character);


            //Assert
            result.Should().BeOfType<BadRequestResult>();
          
        }

    }
}