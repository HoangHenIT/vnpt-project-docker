using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model.OcopModel
{
	public class Nhomsps
	{
		public int ID { get; set; }
		public string? TEN { get; set; }
		public string? MO_TA { get; set; }
		public string? TRANG_THAI { get; set; }
		public Boolean? IS_DELETE { get; set; }
		public int CREATE_USER { get; set; }
		public DateTime CREATED_DATE { get; set; }
		public DateTime UPDATED_DATE { get; set; }
		public int UPDATE_USER { get; set; }
	}
    public class NhomspsRequest
    {
        public int ID { get; set; }
        public string? TEN { get; set; }
        public string? MO_TA { get; set; }
        public string? TRANG_THAI { get; set; }
        public Boolean? IS_DELETE { get; set; }
        public int CREATE_USER { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_DATE { get; set; }
        public int UPDATE_USER { get; set; }
    }
}
