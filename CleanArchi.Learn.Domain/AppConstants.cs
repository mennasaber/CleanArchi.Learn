using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Domain
{
    public class AppConstants
    {
        public const string USER_ROLE = "Customer";
        public const string ADMIN_ROLE = "Admin";
        public const string INVALID_LOGIN = "Invalid email or password";
        public const string USERNAME_REQUIRED_MESSAGE = "Username is required";
        public const string EMAIL_REQUIRED_MESSAGE = "Email is required";
        public const string PASSWORD_REQUIRED_MESSAGE = "Password is required";
        public const string PASSWORD_REQUIRED_LENGTH_MESSAGE = "Minimum length is 8";
        public const string PASSWORD_CONFIRMATION_MESSAGE = "The password and confirmation password don't match.";
        public const string ACCESS_DENIED = "You aren't authorized to access this page";
    }
}
