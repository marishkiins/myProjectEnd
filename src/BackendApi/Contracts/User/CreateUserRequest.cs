﻿using Microsoft.VisualBasic;

namespace BackendApi.Contracts.User
{
    public class CreateUserRequest
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}
