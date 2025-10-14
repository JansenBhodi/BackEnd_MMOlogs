using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Classes;

namespace BusinessLogic.DbCalls
{
    public class MmoPlayerCalls : ImmoPlayerCalls
    {
        public List<MmoPlayer> GetListedPlayers()
        {
			try
			{
				using (var context = new MmoContext())
				{
					return context.MmoPlayers.ToList();
				}
			}
			catch (Exception)
			{
				throw;
			}
        }

		public MmoPlayer GetPlayerByName(string name)
		{
			try
			{
				using (var context = new MmoContext())
				{
					return context.MmoPlayers.Single(p => p.Name == name);
				}
			}
			catch (ArgumentNullException ex)
			{

				throw ex;
			}
			catch (InvalidOperationException ex)
			{
				return null;
			}
		}

		public bool AddNewPlayer(MmoPlayer player)
		{
			try
			{
				using (var context = new MmoContext())
				{
					context.MmoPlayers.Add(player);
					context.SaveChanges();
				}

				return true;
			}
			catch (Exception)
			{

				throw;
			}
		}
    }
}
