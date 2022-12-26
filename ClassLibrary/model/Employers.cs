using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model
{
    public class Employers
    {
        [Key]
        public int employer_id { get; set; }
        public string? full_name { get; set; }
        public string? email { get; set; }
        public string? number_phone { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public int role_id { get; set; }
        public Boolean active { get; set; }

    }
}
