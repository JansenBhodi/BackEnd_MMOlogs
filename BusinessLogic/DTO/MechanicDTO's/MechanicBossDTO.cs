using BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO.MechanicDTO_s
{
    public class MechanicBossDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxLife { get; set; }
        public int Level { get; set; }

        public MechanicBossDTO(Boss input) 
        {
            Id = input.Id;
            Name = input.Name;  
        }
    }
}
