using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class WebUser
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200), Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public WebUserRole UserRole { get; set; }

        public WebUser()
        {

        }

        public WebUser(int id, string username, string password, WebUserRole role)
        {
            Id = id;
            Username = username;
            Password = password;
            UserRole = role;
        }

        //account creation
        public WebUser(string username, string password, WebUserRole role)
        {
            Username = username;
            Password = password;
            UserRole = role;
        }
    }
}
