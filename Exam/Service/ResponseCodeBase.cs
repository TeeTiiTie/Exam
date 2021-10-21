namespace Exam.Service
{
    public class ResponseCodeBase
    {
        public enum ResponseCode
        {
            Successful = 0,
            RequireFieldOrParametersIsNull = 102,
            MethodNotAllowed = 405,
            OtherError = 999
        }
        public static string GetResponseMessage(int responseCode)
        {
            var message = (responseCode == (int)ResponseCode.Successful) ? "Successful"
                        : (responseCode == (int)ResponseCode.RequireFieldOrParametersIsNull) ? "Require field or parameter is null"
                        : (responseCode == (int)ResponseCode.MethodNotAllowed)? "Data have in Database"
                        : (responseCode == (int)ResponseCode.OtherError) ? "OtherError"
                        : "n/a";
            return message;
        }
    }
}
