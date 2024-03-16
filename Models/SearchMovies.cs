using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMovies.Models
{
    /// <summary>
    /// Position model class
    /// </summary>
    public class Movies
    {
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Popularity { get; set; }
        public string VoteCount { get; set; }
        public string VoteAverage { get; set; }
        public string OriginalLanguage { get; set; }
        public string Genre { get; set; }
        public string PosterUrl { get; set; }
    }

    public class MovieSearch
    {
        public List<Movies> ListMovies { get; set; }

        [StringLength(30, ErrorMessage = "There is an issue with the search entry")]
        [Display(Name = "Movie Title Search")]
        public string MovieTitleSearch { get; set; }

        [StringLength(30, ErrorMessage = "There is an issue with the search entry")]
        [Display(Name = "Genre Search")]
        public string GenreSearch { get; set; }

        [StringLength(4, ErrorMessage = "There is an issue with the page limit entry")]
        [Display(Name = "Limit Search Results")]
        public string LimitSearchResults { get; set; }
        public int PageCount { get; set; }

    }
}
