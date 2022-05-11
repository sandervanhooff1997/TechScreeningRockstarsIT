using System;
using System.Linq;
using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommandValidator: AbstractValidator<CreateArtistCommand>
    {
        public CreateArtistCommandValidator(IApplicationDbContext context)
        {
            RuleFor(a => a.Name)
                .MinimumLength(3)
                .NotEmpty()
                .Must(name => !context.Artists.Any(a => a.Name == name))
                .WithMessage("Artist already exists");
        }
        
    }
}