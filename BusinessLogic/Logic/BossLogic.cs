using BusinessLogic.Classes;
using BusinessLogic.DbCalls;
using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class BossLogic
    {
        private IBossCalls _bossDb;

        public BossLogic(IBossCalls bossDb)
        {
            _bossDb = bossDb;
        }

        public List<BossOverviewDTO> GetBosses()
        {
            List<BossOverviewDTO> result = new List<BossOverviewDTO>();

            try
            {
                result = _bossDb.GetBosses();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public BossDetailDTO GetBoss(int id)
        {
            Boss output = new Boss();

            try
            {
                output = _bossDb.GetBoss(id);
                try
                {
                    BossDetailDTO result = new BossDetailDTO(output);

                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boss AddBoss(BossCreateDTO boss)
        {
            try
            {
                return _bossDb.AddBoss(boss);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
