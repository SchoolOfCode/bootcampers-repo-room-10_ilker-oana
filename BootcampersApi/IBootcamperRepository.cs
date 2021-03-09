using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootcampersApi
{
    public interface IBootcamperRepository
    {
        Task<IEnumerable<Bootcamper>> GetAll(int limit, int page);
        Task Delete(long id);
        Task<Bootcamper> GetOne(long id);
        Task<Bootcamper> Update(Bootcamper Bootcamper);
        Task<Bootcamper> Insert(Bootcamper Bootcamper);
        Task<IEnumerable<Bootcamper>> Search(string search, int limit, int page);
    }

}