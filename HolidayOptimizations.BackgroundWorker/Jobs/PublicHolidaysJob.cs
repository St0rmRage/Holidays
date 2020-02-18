using FluentScheduler;
using HoildayOptimizations.Integrations;
using HolidayOptimizations.Common.Helpers.Api;
using HolidayOptimizations.Service.Controllers.Enums;
using HolidayOptimizations.Service.Entities.Features.Holidays;
using HolidayOptimizations.StorageRepository.DataRepositoryInterface.Features.Holidays;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayOptimizations.BackgroundWorker.Jobs
{
    public class PublicHolidaysJob : IJob
    {

        private IHolidaysRepository _repository;
        private INaggerClient _naggerClient;

        public PublicHolidaysJob(IHolidaysRepository repository, INaggerClient naggerClient)
        {
            _repository = repository;
            _naggerClient = naggerClient;
        }

        public void Execute()
        {
            var year = DateTime.Now.Year;

            _repository.DeleteHolidaysByYear(year);
            foreach (var enumValue in Enum.GetValues(typeof(CountryCodesEnum)))
            {
                var holidays = _naggerClient.GetPublicHolidays(year, enumValue.ToString()).Result;
                holidays.ForEach(x => x.EndDate = x.Date.AddHours(24));
                _repository.InsertHolidays(holidays);
            }
                
        }
    }
}
