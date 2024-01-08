using ShaTask.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Services
{
    public interface  IInvoiceHeaderAndInvoiceDetailsService
    {
        IEnumerable<InvoiceHeaderAndDetailsDto> GetAllInvoices();
    }
}
