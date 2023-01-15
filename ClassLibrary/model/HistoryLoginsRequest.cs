using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model
{
    public class HistoryLoginsRequest
    {

        public int employer_id { get; set; }
        public string? startDate { get; set; }
        public string? endDate { get; set; }
    }
}
