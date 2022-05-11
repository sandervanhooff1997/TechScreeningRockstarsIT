using System;
using System.Runtime.Serialization;
using Application.Artists.Queries.GetArtistsByName;
using Application.Common.Mappings;
using Application.Songs.Queries.GetSongsByGenre;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Application.UnitTests.Common.Mappings
{
    [TestFixture]
    public class MappingProfileTests
    {
        private readonly IMapper _mapper;

        public MappingProfileTests()
        {
            IConfigurationProvider configuration = new MapperConfiguration(config => 
                config.AddProfile<MappingProfile>());

            _mapper = configuration.CreateMapper();
        }

        [Test]
        public void Artist_WhenMapped_ShouldMapToArtistDto()
        {
            var artist = new Artist()
            {
                Id = 1,
                Name = "Artist"
            };

            var artistDto = _mapper.Map<ArtistDto>(artist);

            artistDto.Id.Should().Be(artist.Id);
            artistDto.Name.Should().Be(artist.Name);
        }

        [Test]
        public void Song_WhenMapped_ShouldMapToSongDto()
        {
            var song = new Song()
            {
                Id = 1,
                Name = "Song",
                Year = 1900,
                Artist = "Artist",
                Shortname = "Shortname",
                Bpm = 1,
                Duration = 1,
                Genre = "Genre",
                SpotifyId = "SpotifyId",
                Album = "Album"
            };

            var songDto = _mapper.Map<SongDto>(song);

            songDto.Id.Should().Be(song.Id);
            songDto.Name.Should().Be(song.Name);
            songDto.Year.Should().Be(song.Year);
            songDto.Artist.Should().Be(song.Artist);
            songDto.Shortname.Should().Be(song.Shortname);
            songDto.Bpm.Should().Be(song.Bpm);
            songDto.Duration.Should().Be(song.Duration);
            songDto.Genre.Should().Be(song.Genre);
            songDto.SpotifyId.Should().Be(song.SpotifyId);
            songDto.Album.Should().Be(song.Album);
        }
    }
}