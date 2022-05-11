namespace Domain.Entities
{
    public class Song
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Artist { get; set; }
        
        public string Shortname { get; set; }
        
        public int? Bpm { get; set; }
        
        public int Duration { get; set; }
        
        public string Genre { get; set; }
        
        public string SpotifyId { get; set; }
        
        public string Album { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, " +
                   $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Year)}: {Year}, " +
                   $"{nameof(Artist)}: {Artist}, " +
                   $"{nameof(Shortname)}: {Shortname}, " +
                   $"{nameof(Bpm)}: {Bpm}, " +
                   $"{nameof(Duration)}: {Duration}, " +
                   $"{nameof(Genre)}: {Genre}, " +
                   $"{nameof(SpotifyId)}: {SpotifyId}, " +
                   $"{nameof(Album)}: {Album}";
        }
    }
}