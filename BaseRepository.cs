
using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;

public class BaseRepository
{
    // Generate new connection based on connection string
    IConfiguration _configuration;

    public BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    private NpgsqlConnection SqlConnection()
    {
        // This builds a connection string from our separate credentials
        // TODO: add your connection settings (and convert to using user-secrets)
        var stringBuilder = new NpgsqlConnectionStringBuilder
        {
            Host = _configuration["PGHOST"],
            Database = _configuration["PGDATABASE"],
            Username = _configuration["PGUSER"],
            Password = _configuration["PGPASSWORD"],
            Port = 5432,
            SslMode = Npgsql.SslMode.Require, // Heroku Specific Setting
            TrustServerCertificate = true // Heroku Specific Setting
        };

        return new NpgsqlConnection(stringBuilder.ConnectionString);
    }

    // Open new connection and return it for use
    public IDbConnection CreateConnection()
    {
        var connection = SqlConnection();
        connection.Open();
        return connection;
    }

}