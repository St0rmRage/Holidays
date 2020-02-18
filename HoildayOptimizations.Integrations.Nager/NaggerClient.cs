using HoildayOptimizations.Integrations;
using HolidayOptimizations.Common.Helpers.Api;
using HolidayOptimizations.Service.Entities.Features.Holidays;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidayOptimizations.Common.Helpers.Api
{
    /// <summary>
    /// A wrapper class for public holidays api
    /// </summary>
    public class NaggerClient : ApiRequestWrapper, INaggerClient
    {

        public async Task<List<PublicHoliday>> GetPublicHolidays(long year, string countryCode)
        {
            var url = string.Format("https://date.nager.at/api/v2/publicholidays/{0}/{1}", year, countryCode);
            var response = await Get<List<PublicHoliday>>(url);

            return response;
        }

        public async Task<Country> GetCountryInfo(string countryCode)
        {
            var url = string.Format("https://date.nager.at/Api/v2/CountryInfo?countryCode={0}", countryCode);
            var response = await Get<Country>(url);

            return response;
        }
        public async Task<Timezone> GetCountryTimezones(string countryCode)
        {
            var url = string.Format("https://restcountries.eu/rest/v2/alpha/{0}", countryCode);
            var response = await Get<Timezone>(url);

            return response;
        }
    }
}
