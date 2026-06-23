using BusinessLogic.Classes;
using BusinessLogic.DbCalls;
using BusinessLogic.DTO.RaidLogDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class RaidLogLogic
    {
        private IRaidLogCalls _dbCall;

        public RaidLogLogic(IRaidLogCalls dbCall)
        {
            _dbCall = dbCall;
        }

        public List<RaidLog> AddRaidLog(RaidLogCreateDTO input)
        {
            try
            {
                if(input.Uploader != "")
                {
                    throw new ArgumentException(message: "Uploader name cannot be blank.");
                }

                try
                {
                    foreach(var pull in input.pulls)
                    {

                    }
                }
                catch (Exception)
                {

                    throw;
                }

                return _dbCall.CreateRaidLog(input);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
