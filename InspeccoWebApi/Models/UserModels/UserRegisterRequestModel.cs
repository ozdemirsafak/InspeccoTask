﻿namespace InspeccoWebApi.Models.UserModels
{
    public class UserRegisterRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? UserId { get; set; }
    }
}
