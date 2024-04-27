using Api.Dto.CountryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Admin_Core.Entities.Dto
{
    [Serializable]
    public class ServiceResponseStronglyTyped<T> : ServiceResponse
    {
        public new T? Data { get; set; }

        public static ServiceResponseStronglyTyped<T> TypedSuccess(T? data)
        {
            return new ServiceResponseStronglyTyped<T>()
            {
                Data = data,
                IsSuccess = true
            };
        }

        public static new ServiceResponseStronglyTyped<T> Fail(Error[] errorData)
        {
            return new ServiceResponseStronglyTyped<T>
            {
                ErrorData = errorData,
                IsSuccess = false
            };
        }

        public static new ServiceResponseStronglyTyped<T> Fail(Error errorData)
        {
            return new ServiceResponseStronglyTyped<T>
            {
                ErrorData = new[] { errorData },
                IsSuccess = false
            };
        }
    }
}
