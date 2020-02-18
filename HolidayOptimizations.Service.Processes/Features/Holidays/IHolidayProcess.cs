using HolidayOptimizations.Service.Entities;
using HolidayOptimizations.Service.Entities.Reponse;
using System;

namespace HolidayOptimizations.Service.Processes
{
    public interface IHolidaysProcess
    {
        BaseResponse<string> GetCountryWithMostHolidays(long year);

        BaseResponse<string> GetMostHolidaysByMonth(long year);

        BaseResponse<string> GetCountryWithMostUniqueHolidays(long year);

        BaseResponse<LightspeedTravelResponse> LightSpeedTravel(long year);
    }
}
