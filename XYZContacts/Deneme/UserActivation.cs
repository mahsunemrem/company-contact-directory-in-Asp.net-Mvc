using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme
{
    public class UserActivation
    {
        [Key]
        [ForeignKey("User")]
        public Guid Id { get; set; }
        public bool Active { get; set; }

        public virtual User User { get; set; }
    }
}
