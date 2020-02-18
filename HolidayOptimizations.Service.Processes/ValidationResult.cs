using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HolidayOptimizations.Service.Processes
{
    public class ValidationException : Exception
    {
        public ValidationException(Type property, bool isValid) : base(!isValid ? $"Property of type {property.Name} is not valid" : "")
        {
            Property = property;
            IsValid = isValid;
        }

        public Type Property { get; set; }
        public bool IsValid { get; set; }
    }
}
