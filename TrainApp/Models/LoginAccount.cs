﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainApp.Models
{
    public class LoginAccount
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool isAdmin { get; set; }
    }
}