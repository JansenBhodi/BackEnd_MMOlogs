using BusinessLogic.DTO;
using Microsoft.EntityFrameworkCore;
using Repository.Classes;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Classes
{
    [Index(nameof(MmoPlayer.Name), IsUnique = true)]
    public class MmoPlayer
    {
        [Key]
        public int  Id { get; set; }
        [StringLength(200), Required]
        public string Name { get; set; }
        [Required]
        public Roleclass Roleclass { get; set; }


        public MmoPlayer()
        {

        }

        public MmoPlayer(int id, string name, Roleclass roleclass)
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

        //constructor for creating new players
        public MmoPlayer(MmoPlayerCreateDTO input)
        {
            Name = input.Name;
            Roleclass = input.Roleclass;
        }
    }
}
