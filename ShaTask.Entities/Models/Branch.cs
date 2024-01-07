using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Entities.Models
{
    /// <summary>
    ///  Models/Branch.cs
    /// </summary>
    public class Branch
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public int CityId { get; set; }

        // Navigation Property 
        public City City { get; set; }
        public List<Cashier> Cashiers { get; set; }
        public List<InvoiceHeader> InvoiceHeaders { get; set; }

    }
}
