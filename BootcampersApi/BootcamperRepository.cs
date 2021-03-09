using System.Collections.Generic;
using Dapper;
// using System.Data;
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BootcampersApi
{
    public class BootcamperRepository : BaseRepository, IBootcamperRepository
    {

        public BootcamperRepository(IConfiguration configuration) : base(configuration) { }
        public async Task<IEnumerable<Bootcamper>> GetAll(int limit, int page)
        {
            int offset = Math.Max((page - 1) * limit, 0);
            using var connection = CreateConnection();
            return await connection.QueryAsync<Bootcamper>("SELECT * FROM Bootcampers LIMIT @Limit OFFSET @Offset;", new { Limit = limit, Offset = offset });
        }

        public async Task Delete(long id)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync("DELETE FROM Bootcampers WHERE Id = @Id;", new { Id = id });
        }

        public async Task<Bootcamper> GetOne(long id)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<Bootcamper>("SELECT * FROM Bootcampers WHERE Id = @Id;", new { Id = id });
        }

        public async Task<Bootcamper> Update(Bootcamper bootcamper)
        {
            // TODO: Replace with update method..
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<Bootcamper>("SELECT * FROM Bootcampers WHERE Id = @Id;", new { Id = bootcamper.Id });
        }

        public async Task<Bootcamper> Insert(Bootcamper bootcamper)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<Bootcamper>("INSERT INTO Bootcampers (Name, CatchPhrase) VALUES (@Name, @CatchPhrase) RETURNING *;", bootcamper);
        }

        public async Task<IEnumerable<Bootcamper>> Search(string search, int limit, int page)
        {
            int offset = Math.Max((page - 1) * limit, 0);
            using var connection = CreateConnection();
            return await connection.QueryAsync<Bootcamper>("SELECT * FROM Bootcampers WHERE Name ILIKE @Search OR CatchPhrase ILIKE @Search LIMIT @Limit OFFSET @Offset;", new { Search = $"%{search}%", Limit = limit, Offset = offset });
        }

    }

}