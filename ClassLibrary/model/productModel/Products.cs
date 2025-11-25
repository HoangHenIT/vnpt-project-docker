using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model.productModel
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int category_id { get; set; }
       public string category_name { get; set; }
       public int category_active { get; set; }

        public int product_id { get; set; }
        public string product_name { get; set; }
        public int product_active { get; set; }
        public string product_discount { get; set; }
        public string product_price { get; set; }
        public int product_quantity { get; set; }
        public string product_creatdate { get; set; }
        public string product_description { get; set; }
    }
    public class ProductsRequest
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
        public int category_active { get; set; }

        public int product_id { get; set; }
        public string product_name { get; set; }
        public int product_active { get; set; }
        public string product_discount { get; set; }
        public string product_price { get; set; }
        public int product_quantity { get; set; }
        public string product_creatdate { get; set; }
        public string product_description { get; set; }
    }
    
}
