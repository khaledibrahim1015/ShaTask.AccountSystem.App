using ShaTask.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Models
{
    public class CreateFormVM
    {
        [Display(Name = "Invoice Number :")]
        public int InvoiceNumber { get; set; }

        [Required(ErrorMessage ="Customer Name Is Required !"),
         RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$")]
        [StringLength(100)]
        [Display(Name = "Customer Name :")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name ="Invoice Creation Date :")]
        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;


        [Display(Name ="City Name :")]
        public int CityId { get; set; }
        public List<City>? Cities { get; set; }

        [Display(Name = "Branch Name :")]
        public int BranchId { get; set; }
        public List<Branch> Branches { get; set; } = new List<Branch>();

        [Display(Name = "Cashier Name :")]
        public int CashierId { get; set; }
        public List<Cashier> Cashiers { get; set; } = new List<Cashier>();


    }
}
