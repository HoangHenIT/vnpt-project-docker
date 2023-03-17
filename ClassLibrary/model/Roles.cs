using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model
{
    public class Roles
    {
        [Key]
        public int role_id { get; set; }
        public string? role_name { get; set; }
        public Boolean active { get; set; }
        public string? note { get; set; }
    }
}
