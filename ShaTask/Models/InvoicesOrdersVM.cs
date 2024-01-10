using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Models
{
    public class InvoicesOrdersVM
    {
        [Display(Name ="Invoice No.")]
        public long InvoiceHeaderId { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Creation Date ")]

        public DateTime InvoiceDate { get; set; }
        [Display(Name = "Total Price")]

        public double TotalPrice { get; set; }
        [Display(Name = "Branch Name")]

        public string BranchName { get; set; }
        [Display(Name = "Cashier Name")]

        public string CashierName { get; set; }
    }
}
