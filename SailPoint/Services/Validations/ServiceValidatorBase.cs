using NetBet.Services.Validations;
using SailPoint.Infrastracture;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace SailPoint.Services.Validations
{
    //public abstract class ServiceValidatorBase
    //{
    //    protected virtual IList<NetBetError> Dissect(ValidationResult validationResult)
    //    {
    //        var errors = new List<NetBetError>();
    //        if (!validationResult.IsValid)
    //        {
    //            foreach (var error in validationResult.Errors)
    //            {
    //                errors.Add(new NetBetError(errorMessage: error.ErrorMessage, propertyName: error.PropertyName));
    //            }
    //        }

    //        return errors;
    //    }

    //    protected void Validate(IEnumerable<NetBetError> errors)
    //    {
    //        if (errors.SafeAny())
    //        {
    //            var instance = new NetBetException(errors.ToArray());
    //            throw instance;
    //        }
    //    }
    //}

    public abstract class ServiceValidatorBase
    {
        protected virtual IList<SailPointError> Dissect(ValidationResult validationResult)
        {
            var errors = new List<SailPointError>();
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new SailPointError(errorMessage: error.ErrorMessage, propertyName: error.PropertyName));
                }
            }

            return errors;
        }

        protected void Validate(IEnumerable<SailPointError> errors)
        {
            if (errors.SafeAny())
            {
                var instance = new SailPointException(errors.ToArray());
                throw instance;
            }
        }
    }
}
