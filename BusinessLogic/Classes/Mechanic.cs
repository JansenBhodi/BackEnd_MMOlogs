using BusinessLogic.DTO;
using BusinessLogic.DTO.MechanicDTO_s;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class Mechanic
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int BossId { get; set; }

        public Boss Boss { get; set; }


        public Mechanic()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public Mechanic(MechanicCreateDTO input)
        {
            Name = input.Name;
            Description = input.Description;
            BossId = input.BossId;
        }

        public Mechanic(MechanicUpdateDTO input)
        {
            Id = input.Id;
            Name = input.Name;
            Description = input.Description;
            BossId = input.BossId;
        }
    }
}
