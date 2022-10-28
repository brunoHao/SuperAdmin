﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;

namespace SuperAdmin.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Must Import {0}")]
        [Display(Name = "UserName Or Email")]
        public string? UserNameOrEmail { get; set; }


        [Required(ErrorMessage = "Must Import {0}")]
        [DataType(DataType.Password)]
        [Display]
        public string? Password { get; set; }

        [Display(Name = "Keep Me Login")]
        public bool RememberMe { get; set; }
    }
}
