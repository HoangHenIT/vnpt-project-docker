using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model
{
    public class Employers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int employer_id { get; set; }
        public string? full_name { get; set; }
        public string? name_profile { get; set; }
        public string? job_name { get; set; }
        public string? company { get; set; }
        public string? email { get; set; }
        public string? number_phone { get; set; }
        public string? mobile { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public int role_id { get; set; }
        public Boolean? active { get; set; }
        public string? address { get; set; }
        public string? link_website { get; set; }
        public string? link_git { get; set; }
        public string? link_facebook { get; set; }

    }
}
