using BusinessLogic.Classes;
using BusinessLogic.DbCalls;
using BusinessLogic.DTO;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Classes;
using System.Numerics;

namespace BusinessLogic.Logic
{
    public class PlayersLogic
    {
        private PlayerRepository _playerRepo = new PlayerRepository();

        //Create class that handles data calls (this separates ef when doing unit tests on business logic)
        private ImmoPlayerCalls _dbCall;

        public PlayersLogic(ImmoPlayerCalls dbCall)
        {
            _dbCall = dbCall;
        }

        public List<MmoPlayer> GetListedPlayers()
        {
            List<MmoPlayer> result = new List<MmoPlayer>();

            try
            {
                result = _dbCall.GetListedPlayers();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public MmoPlayer GetPlayer(string name)
        {
            try
            {
                return _dbCall.GetPlayerByName(name);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public MmoPlayer AddPlayer(MmoPlayerCreateDTO player)
        {
            try
            {
                //Validate if assigned role exists.
                if(!Enum.IsDefined(typeof(Roleclass), player.Roleclass))
                {
                    throw new ArgumentException(message: "This is not a valid class number.");
                }
                //A player name is not supposed to be blank
                if(player.Name == "")
                {
                    throw new ArgumentException(message: "Player name cannot be blank.");
                }

                MmoPlayer input = new MmoPlayer(player);

                //Check is user name already exists in database
                try
                {
                    if(_dbCall.GetPlayerByName(input.Name) != null)
                    {
                        throw new ArgumentException();
                    }
                }
                //Why did I do it like this.... Maybe I will fix it later.
                catch (ArgumentException)
                {

                    throw new ArgumentException(message:"This user already exists.");
                }

                //input should be validated at this point, let's add it to the database
                _dbCall.AddNewPlayer(input);

                return input;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
