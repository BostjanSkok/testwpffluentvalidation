using System;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace TestWpfFluentValidation
{
    public class ValidationHelper
    {
        public static ValidationResult Validate<T, K>(K entity)
            where T : IValidator<K>, new()
            where K : class
        {
            IValidator<K> __Validator = new T();
            return __Validator.Validate(entity);
        }

        public static IValidator Validator<T, K>(K entity)
            where T : IValidator<K>, new()
            where K : class
        {
            IValidator<K> __Validator = new T();
            return __Validator;
        }

        public static ValidationResult Validate<T, K>(K entity,string propName)
            where T : IValidator<K>, new()
            where K : class
        {
            IValidator<K> __Validator = new T();
            return __Validator.Validate(entity,propName);
        }


        public static string GetError(ValidationResult result)
        {
            var __ValidationErrors = new StringBuilder();
            foreach (var validationFailure in result.Errors)
            {
                __ValidationErrors.Append(validationFailure.ErrorMessage);
                __ValidationErrors.Append(Environment.NewLine);
            }
            return __ValidationErrors.ToString();
        }
    }
}