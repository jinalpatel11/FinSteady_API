﻿namespace SmartSaver_backend.Models.Request.Users
{
    public class ResetPasswordModel
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
