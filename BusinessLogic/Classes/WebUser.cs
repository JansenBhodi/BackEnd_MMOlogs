using BusinessLogic.DTO.WebUserDTO_s;
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
        public string PasswordHash { get; set; }
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
        public WebUser(WebUserRegisterDTO input)
        {
            Username = input.UserName;
            Password = input.Password;
            UserRole = input.UserRole;
            PasswordHash = RandomString();
        }

        private static Random random = new Random();

        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
