using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Entities.Models
{
    /// <summary>
    /// Models/InvoiceHeader.cs
    /// </summary>
    public class InvoiceHeader
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int? CashierId { get; set; }
        public int BranchId { get; set; }

        // Navigation Property 
        public Cashier Cashier { get; set; }
        public Branch Branch { get; set; }

        public List<InvoiceDetail> InvoiceDetails { get; set; }

    }
}
