using BusinessLogic.Classes;
using BusinessLogic.DbCalls;
using BusinessLogic.DTO;
using BusinessLogic.DTO.MechanicDTO_s;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class MechanicLogic
    {
        //Create class that handles data calls (this separates ef when doing unit tests on business logic)
        private IMechanicsCalls _dbCall;

        public MechanicLogic(IMechanicsCalls dbCall)
        {
            _dbCall = dbCall;
        }

        public MechanicDetailDTO GetMechanic(int id)
        {
            try
            {
                Mechanic output = _dbCall.GetMechanic(id);
                try
                {
                    MechanicDetailDTO result = new MechanicDetailDTO(output);

                    return result;
                }
                catch (Exception)
                {

                    throw new InvalidDataException(message: "Something went wrong whilst converting the data.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Mechanic AddMechanic(MechanicCreateDTO mechanic)
        {
            try
            {
                //mechanic fields are not supposed to be blank
                if (mechanic.Name == "" || mechanic.Description == "")
                {
                    throw new ArgumentException(message: "Mechanic data cannot be blank.");
                }

                Mechanic input = _dbCall.AddMechanic(mechanic);

                return input;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Update Mechanic


        //Delete Mechanic
    }
}
