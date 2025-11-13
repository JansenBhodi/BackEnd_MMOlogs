using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class Boss
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100), Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxLife { get; set; }
        public int Level { get; set; }

        public ICollection<Mechanic> Mechanics { get; set; } = new List<Mechanic>();
        public ICollection<ItemDrop> ItemDrops { get; set; } = new List<ItemDrop>();

        public Boss() 
        {

        }
    }
}
