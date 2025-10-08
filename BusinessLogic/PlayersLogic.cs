using MMOlogs_BackEnd.Classes;
using Repository;
using Repository.Classes;

namespace BusinessLogic
{
    public class PlayersLogic
    {
        private PlayerRepository _playerRepo = new PlayerRepository();

        public PlayersLogic()
        {

        }

        public List<MmoPlayer> GetListedPlayers()
        {
            List<MmoPlayer> result = new List<MmoPlayer>();

            foreach(PlayerDB player in _playerRepo.GetListedPlayers())
            {
                result.Add(new MmoPlayer(player));
            }

            return result;
        }
    }
}
