using System;
using System.Linq;
using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Songs.Commands.CreateSong
{
    public class CreateSongCommandValidator: AbstractValidator<CreateSongCommand>
    {
        public CreateSongCommandValidator(IApplicationDbContext context)
        {
            RuleFor(s => s.Name)
                .MinimumLength(3)
                .NotEmpty()
                .Must(name => !context.Songs.Any(a => a.Name == name))
                .WithMessage("Song already exists");

            RuleFor(s => s.Year)
                .NotEmpty()
                .GreaterThan(1600);

            RuleFor(s => s.Artist)
                .NotEmpty()
                .Must(a => context.Artists.Any(artist => artist.Name == a))
                .WithMessage("The artist that wrote this song does not exist");

            RuleFor(s => s.Shortname)
                .NotEmpty();

            RuleFor(s => s.Duration)
                .NotEmpty();
            
            RuleFor(s => s.Genre)
                .NotEmpty();
        }
        
    }
}