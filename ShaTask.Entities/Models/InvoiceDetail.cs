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
    public class InvoiceDetail
    {
        public long Id { get; set; }
        public string ItemName { get; set; }
        public double ItemCount { get; set; }
        public double ItemPrice { get; set; }
        public int InvoiceHeaderId { get; set; }

        // Navigation Property 

        public InvoiceHeader InvoiceHeader { get; set; }


    }
}
