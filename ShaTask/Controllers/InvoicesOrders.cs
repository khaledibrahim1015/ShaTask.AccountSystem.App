using Microsoft.AspNetCore.Mvc;
using ShaTask.Models;
using ShaTask.Services;

namespace ShaTask.Controllers
{
    public class InvoicesOrdersController : Controller
    {
        private readonly IInvoiceHeaderAndInvoiceDetailsService _invoiceHeaderAndInvoiceDetails;

        public InvoicesOrdersController(IInvoiceHeaderAndInvoiceDetailsService invoiceHeaderAndInvoiceDetails)
        {
            _invoiceHeaderAndInvoiceDetails = invoiceHeaderAndInvoiceDetails;
        }

        public IActionResult Index()
        {
            var InvoicesOrdersLst = _invoiceHeaderAndInvoiceDetails.GetAllInvoices().Select(Vm => new InvoiceHeaderAndDetailsVM()
            {
                InvoiceHeaderId = Vm.InvoiceHeaderId,
                CustomerName = Vm.CustomerName,
                InvoiceDate = Vm.InvoiceDate,
                TotalPrice = Vm.TotalPrice,
                CashierName = Vm.CashierName,
                BranchName  = Vm.BranchName,
               
            }).ToList();
            return View(InvoicesOrdersLst);
        }
    }
}
