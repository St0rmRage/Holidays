using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayOptimizations.Service.Entities.Features.Holidays
{
    public class Timezone : BaseEntity
    {
        // Country code
        public string CountryCode { get; set; }

        //Timezone
        public string TimezoneUTC { get; set; }

        //List of timezones the specific country has
        public List<string> Timezones { get; set; }

        public Timezone()
        {
            Timezones = new List<string>();
        }
    }
}
