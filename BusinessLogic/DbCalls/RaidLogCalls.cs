using BusinessLogic.Classes;
using BusinessLogic.DTO.RaidLogDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DbCalls
{
    public class RaidLogCalls : IRaidLogCalls
    {

        public List<RaidLog> CreateRaidLog(RaidLogCreateDTO input)
        {
			int counter = input.pulls.Count();
			try
			{
				List<RaidLog> output = new List<RaidLog>();
				using(var context = new MmoContext())
				{
					for (int i = 0; i < counter; i++)
                    {
                        RaidLog entry = new RaidLog(input, i);
                        context.RaidLogs.Add(entry);
						output.Add(entry);
                    }
					context.SaveChanges();
					return output;
				}

			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
