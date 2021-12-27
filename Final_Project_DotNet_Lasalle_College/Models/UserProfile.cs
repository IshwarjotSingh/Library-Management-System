using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_DotNet_Lasalle_College.Models
{
    public class UserProfile
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}