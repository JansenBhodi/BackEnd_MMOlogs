using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO.WebUserDTO_s
{
    public class WebUserLoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public WebUserLoginDTO(string username, string password)
        {
            UserName = username; 
            Password = password;
        }
    }
}
