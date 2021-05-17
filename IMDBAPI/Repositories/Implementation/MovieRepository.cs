using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IMDBAPI.Models.Database;
using IMDBAPI.Models.Request;
using IMDBAPI.Models.Response;
using Microsoft.Extensions.Options;

namespace IMDBAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {

        private readonly ConnectionString _connectionString;
    

        public MovieRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
           
        }
        public IEnumerable<MovieResponse> GetAllMovies()
        {
            List<MovieResponse> movieResponses = new List<MovieResponse>();
            using var connection = new SqlConnection(_connectionString.DB);

            foreach (var m in connection.Query<MovieResponse>(@"SELECT *
                                                                FROM Movies;")) {
                var Id = m.Id;
                var movie = connection.QuerySingle<Movie>(@"Select *
                                                            FROM Movies A
                                                            WHERE A.ID = " + Id + ";");

                var actors = connection.Query<Actor>(@"SELECT *
                                                   FROM Actors A
                                                   INNER JOIN MovieActorMapping MA
                                                     ON MA.ActorId = A.Id
                                                   WHERE MA.MovieId =  " + Id + ";").AsList<Actor>();

                var genres = connection.Query<Genre>(@"SELECT *
                                                   FROM Genres G
                                                   INNER JOIN MovieGenreMapping MG
                                                     ON MG.GenreId = G.Id
                                                   WHERE MG.MovieId =  " + Id + ";").AsList<Genre>();

                movieResponses.Add(new MovieResponse { Id = movie.Id, Name = movie.Name, Year = movie.Year, Plot = movie.Plot, ProducerId = movie.ProducerId, Actors = actors, Genres = genres, CoverImage = movie.CoverImage });

            }
            return movieResponses;
        }

        public MovieResponse GetMovieById(int Id)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            var movie = connection.QuerySingle<Movie>(@"SELECT *
                                                        FROM Movies M
                                                        WHERE M.Id =  " + Id + ";");

            var actors = connection.Query<Actor>(@"SELECT *
                                                   FROM Actors A
                                                   INNER JOIN MovieActorMapping MA
                                                     ON MA.ActorId = A.Id
                                                   WHERE MA.MovieId =  " + Id + ";").AsList<Actor>();

            var genres = connection.Query<Genre>(@"SELECT *
                                                   FROM Genres G
                                                   INNER JOIN MovieGenreMapping MG
                                                     ON MG.GenreId = G.Id
                                                   WHERE MG.MovieId =  " + Id + ";").AsList<Genre>();

            return new MovieResponse { Id = movie.Id, Name = movie.Name, Year = movie.Year, Plot = movie.Plot, ProducerId = movie.ProducerId, Actors = actors, Genres = genres, CoverImage = movie.CoverImage };

        }

        public MovieResponse GetMovieByName(string name)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            var movie = connection.QuerySingle<Movie>(@"SELECT *
                                                        FROM Movies M
                                                        WHERE M.Name =  " + name + ";");

            var actors = connection.Query<Actor>(@"SELECT *
                                                   FROM Actors A
                                                   INNER JOIN MovieActorMapping MA
                                                     ON MA.ActorId = A.Id
                                                   WHERE MA.MovieId =  " + movie.Id + ";").AsList<Actor>();

            var genres = connection.Query<Genre>(@"SELECT *
                                                   FROM Genres G
                                                   INNER JOIN MovieGenreMapping MG
                                                     ON MG.GenreId = G.Id
                                                   WHERE MG.MovieId =  " + movie.Id + ";").AsList<Genre>();

            return new MovieResponse { Id = movie.Id, Name = movie.Name, Year = movie.Year, Plot = movie.Plot, ProducerId = movie.ProducerId, Actors = actors, Genres = genres, CoverImage = movie.CoverImage };

        }


        public int AddMovie(Movie movie, string MovieActorMappingString,string MovieGenreMappingString)
        {
            //try
            //{
                using var connection = new SqlConnection(_connectionString.DB);
                var ActorIds = MovieActorMappingString;
                var GenreIds = MovieGenreMappingString;
                return connection.Execute("Insert_Movie", new { movie.Id, movie.Name, movie.Year, movie.Plot, movie.ProducerId, ActorIds, GenreIds, movie.CoverImage }, commandType: CommandType.StoredProcedure);
            //}
            //catch (SqlException) { }
            //return -1;
        }

        public void UpdateMovie(int ID, Movie movie,  string MovieActorMappingString, string MovieGenreMappingString)
        {
            using var connection = new SqlConnection(_connectionString.DB);
            var ActorIds = MovieActorMappingString;
            var GenreIds = MovieGenreMappingString;
            connection.Execute("Update_Movie", new { ID, movie.Name, movie.Year, movie.Plot, movie.ProducerId, ActorIds, GenreIds, CoverImage = movie.CoverImage }, commandType: CommandType.StoredProcedure);
        }


        public void DeleteMovie(int Id) {

            using var connection = new SqlConnection(_connectionString.DB);
            
            connection.Execute(@"DELETE FROM MovieActorMapping
                                 WHERE MovieActorMapping.MovieId = @Id", new { Id });

            connection.Execute(@"DELETE FROM MovieGenreMapping
                                 WHERE MovieGenreMapping.MovieId = @Id", new { Id });

            connection.Execute(@"DELETE FROM Movies
                                 WHERE Movies.Id = @Id", new { Id });
        }


    }


}
