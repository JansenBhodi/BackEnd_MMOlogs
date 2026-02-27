using BusinessLogic.Classes;
using BusinessLogic.DTO.MechanicDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DbCalls
{
    public interface IMechanicsCalls
    {

        public Mechanic AddMechanic(MechanicCreateDTO input);
        public Mechanic GetMechanic(int id);
        public Mechanic UpdateMechanic(MechanicUpdateDTO input);
        public bool DeleteMechanic(int id);

    }
}
