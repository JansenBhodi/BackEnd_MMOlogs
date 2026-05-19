using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO.RaidLogDTO_s
{
    public class RaidLogCreateDTO
    {
        public string Uploader { get; set; }
        public string Player { get; set; }
        public DateTime LogDate { get; set; }

        public List<RaidLogEntry> pulls { get; set; }

        public class RaidLogEntry
        {
            public string BossName { get; set; }
            public int DamageDone { get; set; }
            public int DeathCount { get; set; }
            public int HealingDone { get; set; }

            public RaidLogEntry()
            {
                BossName = string.Empty;
            }
        }

        public RaidLogCreateDTO()
        {
            Uploader = string.Empty;
        }
    }
}
