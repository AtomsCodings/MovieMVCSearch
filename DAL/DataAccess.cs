using SearchMovies.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SearchMovies.DAL
{
    /// <summary>
    /// Data access class
    /// </summary>
    public class DataAccess
    {
        SqlConnection connection;
        SqlCommand command;

        /// <summary>
        /// Constructor
        /// </summary>
        public DataAccess()
        {
            connection = new SqlConnection();
            connection.ConnectionString = @"Removed";
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
        }

        /// <summary>
        /// Get movies
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Movies> GetMovies(MovieSearch model)
        {
            List<Movies> ListOfMovies = new List<Movies>();

            if (!string.IsNullOrEmpty(model.MovieTitleSearch))
            {
                var command = new SqlCommand("SearchMovieTitle", connection);
                ListOfMovies = GetMovieDbResults(command, model.MovieTitleSearch);
            }

            else if (!string.IsNullOrEmpty(model.GenreSearch))
            {
                var command = new SqlCommand("SearchMovieGenre", connection);
                ListOfMovies = GetMovieDbResults(command, model.GenreSearch);
            }

            return LimitMovieDbResults(model, ListOfMovies);
        }

        /// <summary>
        /// Limit movie db results
        /// </summary>
        /// <param name="model"></param>
        /// <param name="ListOfMovies"></param>
        /// <returns></returns>
        private List<Movies> LimitMovieDbResults(MovieSearch model, List<Movies> ListOfMovies)
        {
            if (!string.IsNullOrEmpty(model.LimitSearchResults))
            {
                bool success = int.TryParse(model.LimitSearchResults, out int limitBy);

                if (success && ListOfMovies.Count > limitBy)
                {
                    var shortenedListOfMovies =ListOfMovies.Take(limitBy).ToList();
                    return shortenedListOfMovies.ToList();
                }
            }
            return ListOfMovies;
        }

        /// <summary>
        /// Get movie db results
        /// </summary>
        /// <param name="command"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        private List<Movies> GetMovieDbResults(SqlCommand command, string searchString)
        {
            List<Movies> moviesList = new List<Movies>();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Search", searchString);

            try
            {
                using (command)
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Movies movies = new Movies();

                            movies.ReleaseDate = reader["Release_Date"].ToString();
                            movies.Title = reader["Title"].ToString();
                            movies.Overview = reader["Overview"].ToString();
                            movies.Popularity = reader["Popularity"].ToString();
                            movies.VoteCount = reader["Vote_Count"].ToString();
                            movies.VoteAverage = reader["Vote_Average"].ToString();
                            movies.OriginalLanguage = reader["Original_Language"].ToString();
                            movies.Genre = reader["Genre"].ToString();
                            movies.PosterUrl = reader["Poster_URL"].ToString();

                            moviesList.Add(movies);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                //TODO
                return moviesList;
            }
            finally
            {
                connection.Close();
            }

            return moviesList;
        }
    }
}
