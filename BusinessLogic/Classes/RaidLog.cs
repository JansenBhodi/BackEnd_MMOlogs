using BusinessLogic.DTO.RaidLogDTO_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class RaidLog
    {
        [Required, Key]
        public int Id { get; set; }
        [StringLength(200), Required]
        public string Uploader { get; set; }
        [StringLength(200), Required]
        public string PlayerName { get; set; }
        [Required]
        public DateTime LogDate { get; set; }
        [StringLength(100), Required]
        public string BossName { get; set; }
        [Required]
        public int DamageDone { get; set; }
        [Required]
        public int DeathCount { get; set; }
        [Required]
        public int HealingDone { get; set; }


        public RaidLog()
        {

        }

        public RaidLog(RaidLogCreateDTO input, int entry)
        {
            Uploader = input.Uploader;
            PlayerName = input.PlayerName;
            LogDate = input.LogDate;
            BossName = input.entries[entry].BossName;
            DeathCount = input.entries[entry].DeathCount;
            DamageDone = input.entries[entry].DamageDone;
            HealingDone = input.entries[entry].HealingDone;
        }

    }
}
