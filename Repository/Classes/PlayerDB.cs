using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class PlayerDB
    {
        public int IdDb { get; private set; }
        public string NameDb { get; set; }
        public int RoleclassDb { get; set; }

        public PlayerDB(int idDb, string nameDb, int roleclassDb) 
        {
            IdDb = idDb;
            NameDb = nameDb;
            RoleclassDb = roleclassDb;
        }

    }
}
