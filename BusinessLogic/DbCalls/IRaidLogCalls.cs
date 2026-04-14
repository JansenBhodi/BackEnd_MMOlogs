using BusinessLogic.Classes;
using BusinessLogic.DTO.RaidLogDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DbCalls
{
    public interface IRaidLogCalls
    {
        public List<RaidLog> CreateRaidLog(RaidLogCreateDTO input);
    }
}
