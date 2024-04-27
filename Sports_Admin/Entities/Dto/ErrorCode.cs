
namespace Api.Dto.CountryDto
{
    public static class ErrorCode
    {
        public const string None = "None";
        public const string DuplicateField = "DuplicateField";
        public const string RequiredField = "RequiredField";
        public const string RequiredSetOfFields = "RequiredSetOfFields";
        public const string InvalidInput = "InvalidInput";
        public const string NotFound = "NotFound";
        public const string InternalSystemError = "InternalSystemError";
        public const string ValidationError = "ValidationError";
        public const string YaqeenError = "YaqeenError";
        public const string SystemError = "SystemError";
        public const string SmsTemplateNotFoundError = "SmsTemplateNotFoundError";
        public const string AddNotificationError = "AddNotificationError";
        public const string AttorneyInfoNotFound = "AttorneyInfoNotFound";
        public const string MojAuthenticationError = "MojAuthenticationError";
        public const string NafathNewLoginRequestError = "NafathNewLoginRequestError";
        public const string InvalidOrExpiredOtp = "InvalidOrExpiredOtp";
        public const string PhoneIsAlreadyVerified = "PhoneIsAlreadyVerified";
        public const string EmailIsAlreadyVerified = "EmailIsAlreadyVerified";
        public const string AdLoginError = "AdLoginError";
        public const string BlockedSeerError = "BlockedSeerError";
        public const string SeerRequestExist = "SeerRequestExist";
    }
}