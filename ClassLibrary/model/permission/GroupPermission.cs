using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model.permission
{
    public class GroupPermission
    {
        [Key]
        public int  role_id { get; set; }
        public int category_id { get; set; }
        public DateTime createday { get; set; }
    }
}
