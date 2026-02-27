using BusinessLogic.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLogic.DTO.BossDTO_s
{
    public class BossItemDropDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Vitality { get; set; }
        public StatInfo ClassStat { get; set; } = new();
        public StatInfo PrimaryStat { get; set; } = new();
        public StatInfo SecondaryStat { get; set; } = new();
        public StatInfo? TertiaryStat { get; set; } = new();

        [JsonIgnore]
        public ICollection<Boss> Bosses { get; set; } = new List<Boss>();

        public BossItemDropDTO(ItemDrop input)
        {
            ID = input.ID;
            Name = input.Name;
            Description = input.Description;
            Vitality = input.Vitality;
            ClassStat.StatName = input.ClassStat.StatName;
            ClassStat.StatValue = input.ClassStat.StatValue;
            PrimaryStat.StatName = input.PrimaryStat.StatName;
            PrimaryStat.StatValue = input.PrimaryStat.StatValue;
            SecondaryStat.StatName = input.SecondaryStat.StatName;
            SecondaryStat.StatValue = input.SecondaryStat.StatValue;
            if(input.TertiaryStat != null)
            {
                TertiaryStat.StatName = input.TertiaryStat.StatName;
                TertiaryStat.StatValue = input.TertiaryStat.StatValue;
            }
        }
    }

    [Owned]
    public class StatInfo
    {
        public string StatName { get; set; }
        public int StatValue { get; set; }
    }
}
