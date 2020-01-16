using Autofac;
using LastSundaysInYear.Library;
using LastSundaysInYear.Library.ILastSundayOfMonth;
using LastSundaysInYear.Library.IValidations;
using LastSundaysInYear.Library.Validations;
using LastSundaysInYear.Library._LastSunday;

namespace LastSundaysInYear.App
{
    public class Modules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LastSundays>().As<ILastSundays>();
            builder.RegisterType<Validator>().As<IValidator>();
            builder.RegisterType<LastSunday>().As<ILastSunday>();
        }
    }
}