using LastSundaysInYear.Library.Exceptions;
using LastSundaysInYear.Library.IValidations;

namespace LastSundaysInYear.Library.Validations
{
    public class Validator : IValidator
    {
        public void Validate(int year)
        {
            if (year < 1 || year > 9999)
                throw new InvalidYearException();
        }
    }
}