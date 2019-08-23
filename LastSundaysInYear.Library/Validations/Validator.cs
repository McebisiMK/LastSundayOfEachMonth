using LastSundaysInYear.Library.Exceptions;
using LastSundaysInYear.Library.IValidations;

namespace LastSundaysInYear.Library.Validations
{
    public class Validator : IValidator
    {
        public void Validate(int year)
        {
            if (Invalid(year))
                throw new InvalidYearException();
        }

        private bool Invalid(int year)
        {
            return (year < 1 || year > 9999);
        }
    }
}