namespace NetBet.Services.Validations
{
    public class SailPointError
    {
        public SailPointError(string errorMessage, string propertyName)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
        public string PropertyName { get; }

    }


    public class SailPointException : Exception
    {
        public SailPointException(params SailPointError[] sailPointErrors)
        {
            SailPointErrors = sailPointErrors;
        }

        public SailPointError[] SailPointErrors { get; }
    }
}