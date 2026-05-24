namespace JobPortalAPI.Common.Constant
{
    public static class ResponseConstants
    {
        public const string CODE_SUCCESS = "JOB_PORTAL_SERVICE_200";
        public const string CODE_ERROR = "JOB_PORTAL_SERVICE_500";
        public const string CODE_BAD_REQUEST = "JOB_PORTAL_SERVICE_400";
        public const string CODE_UNAUTHORIZED = "JOB_PORTAL_SERVICE_401";
        public const string CODE_NOT_FOUND = "JOB_PORTAL_SERVICE_404";

        public const string MSG_SUCCESS = "The request fulfilled successfully";
        public const string MSG_ERROR = "Error in performing operation, please try again later";
        public const string MSG_BAD_REQUEST = "Bad Request";
        public const string MSG_UNAUTHORIZED = "Seems there is some problem with session, Please login again";
        public const string MSG_NOT_FOUND = "Requested data was not found";
    }
}