using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model.productModel
{
    public class Categorys
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int category_id { get; set; }
       public string category_name { get; set; }
       public int category_active { get; set; }
    }
    public class CategorysRequest
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
        public int category_active { get; set; }
    }
}
