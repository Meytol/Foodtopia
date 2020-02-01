using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Repository;
using Service.Repository.IRepository;

namespace Service.Repository
{
    public class ProvinceService : GenericRepository<Province>, IProvinceService
    {
        public ProvinceService(DatabaseContext context)
    :base(context)
        {

        }   
    }
}