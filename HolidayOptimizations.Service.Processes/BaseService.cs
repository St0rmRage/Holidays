using System;
using System.Reflection;
using System.Threading.Tasks;

namespace HolidayOptimizations.Service.Processes
{
    public abstract class BaseService
    {
        protected BaseResponse<T> Wrap<T>(Func<T> action)
        {
            try
            {
                var result = action();
                return new BaseResponse<T>(result);
            }
            catch (ValidationException ex)
            {
                return new BaseResponse<T>(ex);
            }
            catch (Exception ex)
            {
                //_logger.Fatal(ex);
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
