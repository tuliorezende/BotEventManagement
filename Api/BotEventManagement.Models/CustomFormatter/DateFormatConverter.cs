using Newtonsoft.Json.Converters;

namespace BotEventManagement.Models.CustomFormatter
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
