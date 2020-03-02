using DataAccess.Context;
using DataAccess.Model;
using ValidationService.Interface;
using ValidationService.Structure;

namespace ValidationService.Service
{
    public class ProvinceValidation : GenericValidation<Province>, IProvinceValidation
    {
        public ProvinceValidation(DatabaseContext context)
    :base(context)
        {

        }   
    }
}