using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagementMVC.Models
{
    public class MvcEmployee
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Nullable<int> Age { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Skills { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Department { get; set; }
    }
}