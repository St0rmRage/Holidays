using HolidayOptimizations.Service.Entities.Features.Holidays;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HoildayOptimizations.Integrations
{
    public interface INaggerClient
    {
        Task<List<PublicHoliday>> GetPublicHolidays(long year, string countryCode);

        Task<Country> GetCountryInfo(string countryCode);

        Task<Timezone> GetCountryTimezones(string countryCode);
    }
}
