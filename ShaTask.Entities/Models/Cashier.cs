using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Entities.Models
{
    /// <summary>
    /// Models/Cashier.cs
    /// </summary>
    public class Cashier
    {
        public int Id { get; set; }
        public string CashierName { get; set; }
        public string BranchId { get; set; }

        // Navigation Property 
        public Branch Branch { get; set; }
        public List<InvoiceHeader> InvoiceHeaders { get; set; }



    }
}
