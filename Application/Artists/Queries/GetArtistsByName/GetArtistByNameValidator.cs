using FluentValidation;

namespace Application.Artists.Queries.GetArtistsByName
{
    public class GetArtistByNameValidator : AbstractValidator<GetArtistByNameQuery>
    {
        public GetArtistByNameValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}