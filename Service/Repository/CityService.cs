using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class CityService : GenericRepository<City>, ICityService
    {
        public CityService(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}