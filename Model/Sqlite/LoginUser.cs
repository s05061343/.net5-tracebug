﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Sqlite
{
    public class LoginUser
    {
        [Key]
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int RoleNo { get; set; }
    }
}
