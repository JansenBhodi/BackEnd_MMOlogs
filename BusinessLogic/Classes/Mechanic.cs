using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
    }
}
