using HolidayOptimizations.Service.Entities;
using HolidayOptimizations.Service.Entities.Reponse;
using System;

namespace HolidayOptimizations.Service.Processes
{
    public interface IHolidaysProcess
    {
        /// <summary>
        /// Get the country that has the most holidays in a year worldwide
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        BaseResponse<string> GetCountryWithMostHolidays(long year);

        /// <summary>
        /// Get the month which has the most holidays in a year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        BaseResponse<string> GetMostHolidaysByMonth(long year);

        /// <summary>
        /// Get the country that has the most unique holidays (E.g. days that no other country had a holiday.)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        BaseResponse<string> GetCountryWithMostUniqueHolidays(long year);

        /// <summary>
        /// What is the longest lasting sequence of holidays around the world you can
        /// find this year if you could travel at lightspeed between countries and timezones?
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        BaseResponse<LightspeedTravelResponse> LightSpeedTravel(long year);
    }
}
