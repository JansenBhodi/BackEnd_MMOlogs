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
    public class BossItemDropDTO : ItemDrop
    {
        public BossItemDropDTO(ItemDrop input)
        {
            ID = input.ID;
            Name = input.Name;
            Description = input.Description;
            Vitality = input.Vitality;
            ClassStat = input.ClassStat;
            PrimaryStat = input.PrimaryStat;
            SecondaryStat = input.SecondaryStat;
            TertiaryStat = input.TertiaryStat;
        }
    }
}
