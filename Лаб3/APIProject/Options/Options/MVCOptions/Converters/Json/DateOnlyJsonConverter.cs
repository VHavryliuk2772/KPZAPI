using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Exceptions;
using Domain;

namespace DateOnlyTimeOnly.AspNet.Converters;

public sealed class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string dateString = reader.GetString()!;
        string dateStringFormat1 = "dd/MM/yyyy";
        string dateStringFormat2 = "yyyy-MM-dd";
        if (DateOnly.TryParseExact(dateString,
            dateStringFormat1, 
            CultureInfo.InvariantCulture, 
            DateTimeStyles.None, 
            out var dateTimeObj))
        {
            return dateTimeObj;
        }
        else if(DateOnly.TryParseExact(dateString,
            dateStringFormat2,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var dateTimeObj2))
        {
            return dateTimeObj2;
        }
        else
        {
            throw new BadRequestException("");
        }
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        var isoDate = value.ToString("dd/MM/yyyy").Replace('.','/');
        writer.WriteStringValue(isoDate);
    }
}
