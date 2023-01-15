using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model
{
    public class HistoryLogins
    {
        [Key]
        public int history_id { get; set; }
        public int employer_id { get; set; }
        public DateTime datetime_login { get; set; }
        public string? username { get; set; }
        public string? system_login { get; set; }
    }
}
