using BotEventManagement.Models.API;
using BotEventManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Test
{
    public class BaseTest
    {
        protected EventRequest CreateEventObject(string eventName, string eventDescription, string startDate, string endDate, string latitude, string longitude, string street)
        {
            var dateStart = DateTime.ParseExact(startDate, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            var dateEnd = DateTime.ParseExact(endDate, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            return new EventRequest
            {
                Address = new Address
                {
                    Latitude = latitude,
                    Longitude = longitude,
                    Street = street

                },
                Description = eventDescription,
                StartDate = dateStart,
                Name = eventName,
                EndDate = dateEnd
            };
        }
    }
}
