using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class CityValidation : GenericValidation<City>, ICityValidation
    {
        public CityValidation(DatabaseContext context)
        :base(context)
        {
            
        }
    }
}