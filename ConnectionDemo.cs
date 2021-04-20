using System;
namespace Application
{
    public class ConnectionDemo
    {
        const string sql = @"
SELECT *
FROM Actors";

            using var connection = new SqlConnection(_connectionString.DB);
    var actors = connection.Query<Actor>(sql);
}
}
