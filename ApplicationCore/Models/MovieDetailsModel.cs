using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    //Create Model based on View
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public string? Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string? ImdbUrl { get; set; }
        public string? TmdbUrl { get; set; }
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public string? OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public decimal? Rating { get; set; }

        public List<CastModel> Casts { get; set; } //call CastModel to get casts corresponding to the movie
        public List<TrailerModel> Trailers { get; set; }
        public List<GenreModel> Genres { get; set; }
        
        public ICollection<Review> Reviews { get; set; }
    }
}
