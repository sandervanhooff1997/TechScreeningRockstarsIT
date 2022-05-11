using System.Linq;
using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommandValidator: AbstractValidator<UpdateArtist.UpdateArtistCommand>
    {
        public UpdateArtistCommandValidator(IApplicationDbContext context)
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .Must(id => context.Artists.Any(a => a.Id == id))
                .WithMessage("Artist does not exist");
            
            RuleFor(a => a.Name)
                .MinimumLength(3)
                .NotEmpty()
                .Must(name => !context.Artists.Any(a => a.Name == name))
                .WithMessage("Artist name already exists");
        }
        
    }
}