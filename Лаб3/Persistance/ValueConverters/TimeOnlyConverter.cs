using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.ValueConverters
{
    internal sealed class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
            d => new TimeSpan(d.Hour, d.Minute, d.Second, d.Millisecond),
            d => TimeOnly.FromTimeSpan(d))
        { 
        }
    }
}
