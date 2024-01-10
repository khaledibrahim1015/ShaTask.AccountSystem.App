using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShaTask.Entities.DTOs;
using ShaTask.Entities.Models;
using ShaTask.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Services.Impelementaion
{
    public class IInvoicesOrdersImpl : IInvoicesOrdersService
    {
        private readonly ApplicationDbContext _context;
        public IInvoicesOrdersImpl(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<InvoicesOrdersDto> GetAllInvoices()
        {

            return _context.InvoiceDetails
            .Join(
                _context.InvoiceHeader,
                id => id.InvoiceHeaderId,
                ih => ih.Id,
                (id, ih) => new { id, ih }
                )
            .Join(
                _context.Cashier,
                joined => joined.ih.CashierId,
                c => c.Id,
                (joined, c) => new { joined.id, joined.ih, c }
            )
            .Join(
                _context.Branches,
                joined => joined.ih.BranchId,
                b => b.Id,
                (joined, b) => new { joined.id, joined.ih, joined.c, b }
            )
            .Join(
                _context.Cities,
                joined => joined.b.CityId,
                cy => cy.Id,
                (joined, cy) => new
                {
                    joined.id.InvoiceHeaderId,
                    joined.ih.CustomerName,
                    joined.ih.InvoiceDate,
                    TotalPrice = joined.id.ItemPrice,
                    joined.b.BranchName,
                    joined.c.CashierName
                }
            )
            .GroupBy(
                result => new
                {
                    result.InvoiceHeaderId,
                    result.CustomerName,
                    result.InvoiceDate,
                    result.BranchName,
                    result.CashierName,

                }
            )
            .Select(
                grouped => new InvoicesOrdersDto()
                {
                    InvoiceHeaderId = grouped.Key.InvoiceHeaderId,
                    CustomerName = grouped.Key.CustomerName,
                    InvoiceDate = grouped.Key.InvoiceDate,
                    TotalPrice = grouped.Sum(x => x.TotalPrice),
                    BranchName = grouped.Key.BranchName,
                    CashierName = grouped.Key.CashierName
                }
            )
            .OrderBy(result => result.InvoiceHeaderId)
            .ToList();
        }



    }
}
