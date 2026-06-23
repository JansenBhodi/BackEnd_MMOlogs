using BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO.WebUserDTO_s
{
    public class WebUserRegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public WebUserRole UserRole { get; set; }

        public WebUserRegisterDTO(string username, string password, WebUserRole role)
        {
            UserName = username;
            Password = password;
            UserRole = role;
        }
    }
}
