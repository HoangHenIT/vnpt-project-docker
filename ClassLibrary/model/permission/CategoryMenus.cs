using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model.permission
{
    public class CategoryMenus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? category_id { get; set; }
        public string? category_name { get; set; }
        public int? category_level { get; set; }
        public string? category_link { get; set; }
        public string? category_icon { get; set; }
        public string? category_note { get; set; }
        public Boolean? category_active { get; set; }
        public DateTime? createday { get; set; }
        public int? category_cha_id { get; set; }
        public int position { get; set; }
    }
}
