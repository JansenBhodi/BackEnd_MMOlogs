using BusinessLogic.Classes;
using BusinessLogic.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic.DbCalls
{
    public class BossCalls : IBossCalls
    {
        public List<BossOverviewDTO> GetBosses()
        {
            try
            {
                using (var context = new MmoContext())
                {
                    return context.Bosses.Select(b => new BossOverviewDTO
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Description = b.Description,
                        MaxLife = b.MaxLife,
                        Level = b.Level
                    }).ToList();
                }
            }
            catch (Exception)
            {
                InvalidOperationException ex = new InvalidOperationException(message: "Retrieval of data from database failed");
                throw ex;
            }
        }

        public Boss GetBoss(int id)
        {
            try
            {
                using (var context = new MmoContext())
                {
                    return context.Bosses
                        .Include(b => b.ItemDrops)
                        .Include(b => b.Mechanics)
                        .Single(b => b.Id == id);
                }
            }
            catch (ArgumentNullException ex)
            {
                ex = new ArgumentNullException(paramName: id.ToString(), message: "There are multiple Bosses with this id.");
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public Boss AddBoss(BossCreateDTO bossCreateDTO)
        {
            try
            {
                using (var context = new MmoContext())
                {
                    Boss input = new Boss(bossCreateDTO);
                    context.Bosses.Add(input);
                    context.SaveChanges();
                    return input;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
