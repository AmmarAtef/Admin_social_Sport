

using Api.Dto.CountryDto;

namespace Sports_Admin_Core.Entities.Dto
{

    [Serializable]
    public class ServiceResponse : ServiceResponse<object>
    {
        public static new ServiceResponse Success(object? data = null)
        {
            return new ServiceResponse()
            {
                Data = data,
                IsSuccess = true
            };
        }
        public static new ServiceResponse Fail(Error[] errorData)
        {
            return new ServiceResponse
            {
                ErrorData = errorData,
                IsSuccess = false
            };
        }

        public static new ServiceResponse Fail(Error errorData)
        {
            return new ServiceResponse
            {
                ErrorData = new[] { errorData },
                IsSuccess = false
            };
        }

    }
    [Serializable]
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public Error[]? ErrorData { get; set; }
        public static ServiceResponse<T> Success(T? data)
        {
            return new ServiceResponse<T>
            {
                Data = data,
                IsSuccess = true
            };
        }

        public static ServiceResponse<T> Fail(Error[] errorData)
        {
            return new ServiceResponse<T>
            {
                ErrorData = errorData,
                IsSuccess = false
            };
        }
    }
}
