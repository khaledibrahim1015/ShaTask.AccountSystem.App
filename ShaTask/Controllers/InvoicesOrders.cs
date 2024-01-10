using Microsoft.AspNetCore.Mvc;
using ShaTask.Models;
using ShaTask.Services;
using System.Web;

namespace ShaTask.Controllers
{
    public class InvoicesOrdersController : Controller
    {
        private readonly IInvoicesOrdersService _invoiceHeaderAndInvoiceDetails;
        private readonly ICityAndBranchAndCashierService _cityAndBranchAndCashierService;

        public InvoicesOrdersController(IInvoicesOrdersService invoiceHeaderAndInvoiceDetails,
            ICityAndBranchAndCashierService cityAndBranchAndCashierService)
        {
            _invoiceHeaderAndInvoiceDetails = invoiceHeaderAndInvoiceDetails;
            _cityAndBranchAndCashierService = cityAndBranchAndCashierService;
        }

        public IActionResult Index()
        {
            var InvoicesOrdersLst = _invoiceHeaderAndInvoiceDetails.GetAllInvoices()
                .Select(Vm => new InvoicesOrdersVM()
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

        [HttpGet]
        public IActionResult Create()
        {
            CreateFormVM createFormVM = new CreateFormVM()
            {
                Cities = _cityAndBranchAndCashierService.GetCitiesDDL().ToList(),
            };



            return View(createFormVM);
        }




        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(int id )
        //{


        //    return RedirectToAction(nameof(Index));
        //}




        [HttpGet]
        public IActionResult GetBranchesDDL([FromQuery] string CityId)
        {
            if (!string.IsNullOrEmpty(CityId))
            {
                var Result = _cityAndBranchAndCashierService.GetBranchesDDL(int.Parse(CityId)).ToList();
                return Result == null ? NotFound() : Ok(Result);
            }
            else
            {
                return BadRequest("CityId is required.");
            }

        }

        [HttpGet]
        public IActionResult GetCashiersDDL([FromQuery] string BranchId)
        {
            if (!string.IsNullOrEmpty(BranchId))
            {
                var result = _cityAndBranchAndCashierService.GetCashiersDDL(int.Parse(BranchId)).ToList();
                return result !=null ? Ok(result) : NotFound();
            }
            else
            {
                return BadRequest("BranchId is Rqueired");
            }

        }



    }
}
