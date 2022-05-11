using FluentValidation;

namespace Application.Artists.Queries.GetArtistsByName
{
    public class GetSongsByGenreValidator : AbstractValidator<GetSongsByGenreQuery>
    {
        public GetSongsByGenreValidator()
        {
            RuleFor(x => x.Genre)
                .NotEmpty();
        }
    }
}