using BusinessLogic.Classes;
using BusinessLogic.DTO.WebUserDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DbCalls
{
    public class WebUserCalls : IWebUserCalls
    {
        public WebUserLoginSuccessDTO WebUserRegister(WebUserRegisterDTO WebUserEntry)
        {
            try
            {
                using(var context = new MmoContext())
                {
                    WebUser input = new WebUser(WebUserEntry);
                    context.WebUsers.Add(input);
                    context.SaveChanges();
                    return new WebUserLoginSuccessDTO(input);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public WebUserLoginSuccessDTO WebUserLogin(WebUserLoginDTO WebUserEntry)
        //{

        //}
    }
}
