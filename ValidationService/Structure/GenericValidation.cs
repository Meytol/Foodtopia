using System;
using DataAccess.Common.Interface;
using DataAccess.Context;

namespace ValidationService.Structure
{
    public class GenericValidation<T> : IGenericValidation<T> where T : class, IAuditable
    {
        protected DatabaseContext Context;

        public GenericValidation(DatabaseContext context)
        {
            Context = context;
        }

        public bool DeleteValidation<T>(T entity, out string validationMessage)
        {
            validationMessage = string.Empty;
            return true;
        }

        public bool InsertValidation<T>(T entity, out string validationMessage)
        {
            validationMessage = string.Empty;
            return true;
        }

        public bool UpdateValidation<T>(T entity, out string validationMessage)
        {
            validationMessage = string.Empty;
            return true;
        }
    }
}