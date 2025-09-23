using Repository.Classes;

namespace Repository
{
    public class PlayerRepository
    {

        public List<PlayerDB> GetListedPlayers()
        {
            List<PlayerDB> result = new List<PlayerDB>();
            result.Add(new PlayerDB(1, "Eric", 1));
            result.Add(new PlayerDB(2, "Janice", 5));
            result.Add(new PlayerDB(3, "Walter", 3));

            return result;

        }

        public PlayerDB GetPlayerById(int id)
        {
            List<PlayerDB> result = new List<PlayerDB>();
            result.Add(new PlayerDB(1, "Eric", 1));
            result.Add(new PlayerDB(2, "Janice", 5));
            result.Add(new PlayerDB(3, "Walter", 3));

            foreach (PlayerDB player in result)
            {
                if(player.IdDb == id)
                {
                    return player;
                }
            }
            throw new Exception();
        }

    }
}
