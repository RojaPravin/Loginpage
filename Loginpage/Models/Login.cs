using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Loginpage.Models
{
    public class Login
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}