using XCRS.Core.Utility;
using XCRS.Services.UserService.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XCRS.Core.Domain.Dtos
{
    public class Response
    {
        private readonly List<ResponseErrorResult> _errorMessages = new();

        public void AddErrorMessage(ResponseErrorResult errorResult) => _errorMessages.Add(errorResult);

        public void AddErrorMessages(ICollection<ResponseErrorResult> errorResults) => _errorMessages.AddRange(errorResults);

        public void AddErrorMessage(string errorCode, string[] errorValues)
        {
            AddErrorMessage(errorCode, "", errorValues);
        }

        public void AddErrorMessage(string errorCode, object p, string[] errorValues)
        {
            throw new NotImplementedException();
        }

        public void AddErrorMessage(CommonErrorCodes commonErrorCode, string[] errorValues,
            string exceptionErrorMessage, string exceptionStackTrace)
        {
            string errorCode = commonErrorCode.DisplayName;
            string errorMessage = commonErrorCode.DisplayMessage;
            AddErrorMessage(errorCode, errorMessage, errorValues, exceptionErrorMessage, exceptionStackTrace);
        }

        public void AddErrorMessage(CommonErrorCodes commonErrorCode, string[] errorValues)
        {
            string errorCode = commonErrorCode.DisplayName;
            string errorMessage = commonErrorCode.DisplayMessage;
            AddErrorMessage(errorCode, errorMessage, errorValues);
        }

        public void AddErrorMessage(string errorCode, string errorMessage, string[] errorValues)
        {
            var errorResult = new ResponseErrorResult
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
            if (errorValues?.Length > 0)
                foreach (var errorValue in errorValues)
                    errorResult.ErrorValues.Add(errorValue);
            AddErrorMessage(errorResult);
        }

        public void AddErrorMessage(string exceptionErrorMessage, string exceptionStackTrace = "")
        {
            AddErrorMessage(CommonErrorCodes.APIServerError.DisplayName
                , CommonErrorCodes.APIServerError.DisplayMessage
                , Array.Empty<string>(), exceptionErrorMessage, exceptionStackTrace);
        }

        /// <summary>
        /// use for gremlin response exception
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        /// <param name="errorValues"></param>
        public void AddCustomizeErrorMessage(
            string errorCode,
            string errorMessage,
            string[] errorValues)
        {
            _errorMessages.Add(new ResponseErrorResult
            {
                ErrorCode = errorCode,
                ErrorMessage = $"Failed: {errorMessage}",
                ErrorValues = new List<string>(errorValues)
            });
        }

        private void AddErrorMessage(
            string errorCode,
            string errorMessage,
            string[] errorValues,
            string exceptionErrorMessage,
            string exceptionStackTrace)
        {
            _errorMessages.Add(new ResponseErrorResult
            {
                ErrorCode = errorCode,
                ErrorMessage = $"Error: {errorMessage}, Exception Message: {exceptionErrorMessage}, Stack Trace: {exceptionStackTrace}",
                ErrorValues = new List<string>(errorValues)
            });
        }

        public IReadOnlyCollection<ResponseErrorResult> ErrorMessages => _errorMessages;
        public bool IsOK => _errorMessages.Count == 0;

        public string ToJSONString()
        {
            return JsonConvert.SerializeObject(this,
                        new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }

    public class Response<T> : Response
    {
        public T? Result { get; set; }

        public bool IsEmptyList<LT>(List<LT> list, string errorValueName)
        {
            if (list == null || list.Count == 0)
            {
                AddErrorMessage(CommonErrorCodes.Required.DisplayName,
                        CommonErrorCodes.Required.DisplayMessage,
                       new[] { ErrorUtil.GenerateErrorMessage(errorValueName, "") });

                return true;
            }
            return false;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1000:Do not declare static members on generic types", Justification = "<Pending>")]
        public static Response<T> CreateResultFromErrorList(IEnumerable<ResponseErrorResult> errorMessages)
        {
            var methodResult = new Response<T>();
            foreach (var error in errorMessages)
                methodResult.AddErrorMessage(error);
            return methodResult;
        }

        public void AddResultFromErrorList(IEnumerable<ResponseErrorResult> errorMessages)
        {
            foreach (var error in errorMessages)
                AddErrorMessage(error);
        }
    }


    public class ResponseErrorResult
    {
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<string> ErrorValues { get; set; } = new List<string>();
    }
}