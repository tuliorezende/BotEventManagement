using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.CustomFormatter
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
