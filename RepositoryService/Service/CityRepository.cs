using DataAccess.Context;
using DataAccess.Model;
using RepositoryService.Interface;
using RepositoryService.Structure;
using ValidationService.Interface;

namespace RepositoryService.Service
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(DatabaseContext context, ICityValidation validation)
        :base(context, validation)
        {
            
        }
    }
}