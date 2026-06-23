using BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO.WebUserDTO_s
{
    public class WebUserLoginSuccessDTO
    {
        public int Id { get; set; }
        public WebUserRole UserRole { get; set; }

        public WebUserLoginSuccessDTO(int id, WebUserRole userRole)
        {
            Id = id;
            UserRole = userRole;
        }
        public WebUserLoginSuccessDTO(WebUser input)
        {
            Id = input.Id;
            UserRole = input.UserRole;
        }
    }
}
