using Microsoft.AspNetCore.Mvc;
using Sports_Admin_Core.Entities.Dto;

namespace Api.Dto
{
    public static class ServiceResponseUtilities
    {
        public static ActionResult<ServiceResponse> HandleServiceResponse(this ControllerBase controllerBase, ServiceResponse serviceResponse)
        {
            if (serviceResponse.IsSuccess)
            {
                return controllerBase.Ok(serviceResponse);
            }

            return controllerBase.NotFound(serviceResponse);
        }
        public static ActionResult<ServiceResponse<T>> HandleServiceResponse<T>(this ControllerBase controllerBase, ServiceResponse<T> serviceResponse)
        {
            if (serviceResponse.IsSuccess)
            {
                return controllerBase.Ok(serviceResponse);
            }
            return controllerBase.NotFound(serviceResponse);
        }

        public static ActionResult<ServiceResponseStronglyTyped<T>> HandleServiceResponse<T>(this ControllerBase controllerBase, ServiceResponseStronglyTyped<T> serviceResponse)
        {
            if (serviceResponse.IsSuccess)
            {
                return controllerBase.Ok(serviceResponse);
            }
            return controllerBase.BadRequest(serviceResponse);
        }

    }
}
