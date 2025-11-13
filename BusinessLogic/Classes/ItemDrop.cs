using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class ItemDrop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Vitality { get; set; }
        public StatInfo ClassStat { get; set; } = new();
        public StatInfo PrimaryStat { get; set; } = new();
        public StatInfo SecondaryStat { get; set; } = new();
        public StatInfo? TertiaryStat { get; set; } = new();


        public ICollection<Boss> Bosses { get; set; } = new List<Boss>(); 
    }

    [Owned]
    public class StatInfo
    {
        public string StatName { get; set; }
        public int StatValue { get; set; }
    }
}
