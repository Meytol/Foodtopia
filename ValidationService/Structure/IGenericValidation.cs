using DataAccess.Common.Interface;

namespace ValidationService.Structure
{
    public interface IGenericValidation<T> where T :class, IAuditable
    {
        bool InsertValidation<T>(T entity, out string message);
        bool UpdateValidation<T>(T entity, out string message);
        bool DeleteValidation<T>(T entity, out string message);
    }
}