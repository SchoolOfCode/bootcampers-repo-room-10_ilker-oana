
 public class FakeRepo : IBootcamperRepository
        {
            List<Bootcamper> _bootcampers = new List<Bootcamper>{new Bootcamper{Id=1, Name="Ben", CatchPhrase = "test"}};
            
           public async Task<IEnumerable<Bootcamper>> GetAll(int limit, int page)
            {
                return _bootcampers;
            }
            public async Task Delete(long id)
            {

            }
            public async Task<Bootcamper> GetOne(long id)
            {
                return _bootcampers[0];
            }
            public async Task<Bootcamper> Update(Bootcamper Bootcamper)
            {
                return _bootcampers[0];
            }
            public async Task<Bootcamper> Insert(Bootcamper Bootcamper)
            {
                return _bootcampers[0];
            }
            public async Task<IEnumerable<Bootcamper>> Search(string search, int limit, int page)
            {
                return _bootcampers;
            }
        }