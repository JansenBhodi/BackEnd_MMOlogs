using BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DbCalls
{
    public interface ImmoPlayerCalls
    {
        public List<MmoPlayer> GetListedPlayers();
        public bool AddNewPlayer(MmoPlayer player);
        public MmoPlayer GetPlayerByName(string name);

    }
}
