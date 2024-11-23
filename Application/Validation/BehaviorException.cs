using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Validation
{
    public class BehaviorException
    {
        public static ModelStateDictionary AddToModelState(ValidationResult result)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (ValidationFailure failure in result.Errors)
            {
                modelStateDictionary.AddModelError(
                    failure.PropertyName,
                    failure.ErrorMessage);
            }
            return modelStateDictionary;
        }
    }
}
