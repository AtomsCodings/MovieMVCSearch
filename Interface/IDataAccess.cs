using SearchMovies.Models;
using System.Collections.Generic;
using System.Reflection;

namespace SearchMovies.Interface
{
    public interface IDataAccess
    {
       List<Movies> GetMovies(string MovieTitleSearch, string GenreSearch, string LimitSearchResults);
    }
}
