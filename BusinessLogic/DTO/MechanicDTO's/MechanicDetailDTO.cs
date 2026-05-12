using BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO.MechanicDTO_s
{
    public class MechanicDetailDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MechanicBossDTO Boss { get; set; }

        public MechanicDetailDTO(Mechanic input) 
        {
            Id = input.Id;
            Name = input.Name;
            Description = input.Description;
            Boss = new MechanicBossDTO(input.Boss);
        }
    }
}
