using BusinessLogic.Classes;
using BusinessLogic.DTO.MechanicDTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DbCalls
{
    public class MechanicsCalls : IMechanicsCalls
    {
        public Mechanic GetMechanic(int id)
        {
            try
            {
                using (var context = new MmoContext())
                {
                    return context.Mechanics.Single(m => m.Id == id);
                }
            }
            catch (ArgumentNullException ex)
            {
                ex = new ArgumentNullException(paramName: id.ToString(), message: "There are multiple Bosses with this id.");
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                ex = new InvalidOperationException(message: "There is no mechanic with this Id.");
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Mechanic AddMechanic(MechanicCreateDTO input)
        {
            try
            {
                using (var context = new MmoContext())
                {
                    Mechanic data = new Mechanic(input);
                    context.Mechanics.Add(data);
                    context.SaveChanges();
                    return data;
                }

            }
            catch (Exception)
            {
                throw new ArgumentException(message: "An error occured trying to create a new mechanic.");
            }
        }

        public Mechanic UpdateMechanic(MechanicUpdateDTO input)
        {
            try
            {
                using(var context = new MmoContext())
                {
                    Mechanic data = new Mechanic(input);
                    context.Mechanics.Update(data);
                    context.SaveChanges();
                    return data;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException(message: "An error occured trying to update the mechanic.");
            }
        }

        public bool DeleteMechanic(int id)
        {
            try
            {
                using(var context = new MmoContext())
                {
                    context.Mechanics.Where(m => m.Id == id).ExecuteDelete();
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
