using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Entities.DTOs
{
    public class InvoicesOrdersDto
    {
        public long InvoiceHeaderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double TotalPrice { get; set; }
        public string BranchName { get; set; }
        public string CashierName { get; set; }

    }
}
