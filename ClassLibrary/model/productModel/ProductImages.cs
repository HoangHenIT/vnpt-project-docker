using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model.productModel
{
    public class ProductImages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productImage_id { get; set; }
        public int product_id { get; set; }
        public string productImage_name { get; set; }
    }
    public class ProductImagesRequest
    {
        public int productImage_id { get; set; }
        public int product_id { get; set; }
        public string productImage_name { get; set; }
    }
    
}
