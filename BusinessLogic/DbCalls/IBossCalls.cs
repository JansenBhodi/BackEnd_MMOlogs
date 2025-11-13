using BusinessLogic.Classes;
using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DbCalls
{
    public interface IBossCalls
    {
        public List<BossOverviewDTO> GetBosses();
        public Boss GetBoss(int id);
    }
}
