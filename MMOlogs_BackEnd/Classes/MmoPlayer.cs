using Repository.Classes;

namespace MMOlogs_BackEnd.Classes
{
    public class MmoPlayer
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public Roleclass Roleclass { get; set; }

        public MmoPlayer(int id,  string name, Roleclass roleclass)
        {
            Id = id;
            Name = name;
            Roleclass = roleclass;
        }

        public MmoPlayer(PlayerDB playerDb)
        {
            Id = playerDb.IdDb;
            Name = playerDb.NameDb;
            Roleclass = (Roleclass)playerDb.RoleclassDb;
        }
    }
}
