using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme
{

    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }

        public virtual UserActivation UserActivation { get; set; }
    }
}
