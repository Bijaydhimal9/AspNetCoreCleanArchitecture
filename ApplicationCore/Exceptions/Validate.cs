using System;

namespace ApplicationCore.Exceptions
{
    public static class Validate
    {
        public static void ValidateArgumentNotNull<T>(T param, string paramName)
            where T : class
        {
            if (param == null)
            {
                throw new ArgumentNullException(paramName, $"{paramName} cannot be null.");
            }
        }
        public static void ValidateArgumentNotNullOrEmpty(string param, string paramName)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentNullException(paramName, $"{paramName} cannot be null.");
            }
        }
        public static void ValidateArgumentNotNullOrEmpty(int param, string paramName)
        {
            if (param == 0)
            {
                throw new ArgumentNullException(paramName, $"{paramName} cannot be null");
            }
        }
        public static void ValidateArgumentStringLength(string param, string paramName)
        {
            if (param.Length > 50 || string.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentNullException(paramName, $"{paramName} length cannot be more then 50");
            }
        }
    }
}
