using BusinessLogic.Classes;
using BusinessLogic.DTO.BossDTO_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class BossDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxLife { get; set; }
        public int Level { get; set; }


        public ICollection<BossMechanicDTO> Mechanics { get; set; } = new List<BossMechanicDTO>();
        public ICollection<BossItemDropDTO> ItemDrops { get; set; } = new List<BossItemDropDTO>();

        public BossDetailDTO(Boss input)
        {
            Id = input.Id;
            Name = input.Name;
            Description = input.Description;
            MaxLife = input.MaxLife;
            Level = input.Level;

            foreach(Mechanic mechanic in input.Mechanics)
            {
                Mechanics.Add(new BossMechanicDTO(mechanic));
            }
            
            foreach(ItemDrop item in  input.ItemDrops)
            {
                ItemDrops.Add(new BossItemDropDTO(item));
            }
        }
    }
}
