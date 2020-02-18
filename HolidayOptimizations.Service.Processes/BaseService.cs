using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Fluent;

namespace HolidayOptimizations.Service.Processes
{
    public abstract class BaseService
    {
        private readonly Logger.ILogger _logger;

        protected BaseService(Logger.ILogger logger = null)
        {
            _logger = logger;
        }

        protected BaseResponse<T> Wrap<T>(Func<T> action)
        {
            try
            {
                var result = action();
                return new BaseResponse<T>(result);
            }
            catch (ValidationException ex)
            {
                _logger?.LogError(ex.Message);
                return new BaseResponse<T>(ex);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                return new BaseResponse<T>(ex);
            }
        }

        protected void Validate<T>(T input, Func<T, bool> validation)
        {
            var type = typeof(T);

            if (!validation(input))
                throw new ValidationException(type, false);
        }
    }
}
