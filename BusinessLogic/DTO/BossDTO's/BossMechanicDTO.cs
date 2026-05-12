using BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class BossMechanicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public BossMechanicDTO(Mechanic input)
        {
            Id = input.Id;
            Name = input.Name;
            Description = input.Description;
        }
    }
}
