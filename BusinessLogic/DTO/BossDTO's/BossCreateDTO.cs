using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class BossCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxLife { get; set; }
        public int Level { get; set; }

        //needed for testing
        //public BossCreateDTO(string name, string desc, int maxLife, int level) 
        //{
        //    Name = name;
        //    Description = desc;
        //    MaxLife = maxLife;
        //    Level = level;
        //}
    }
}
