namespace Domain
{
    public static class ErrorMessages
    {
        public static string UserNotFound { get{ return GetErrorMessage("User"); } }
        public static string UserIsNotAuthorized => "User is not authorized";
        public static string ProductNotFound { get { return GetErrorMessage("Product"); } }
        private static string GetErrorMessage(string name)
        {
            return $"{name} is not found!";
        }
    }
}
