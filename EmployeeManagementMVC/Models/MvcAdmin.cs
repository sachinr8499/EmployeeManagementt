﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagementMVC.Models
{
    public class MvcAdmin
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
    }
}