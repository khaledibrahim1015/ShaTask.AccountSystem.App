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

namespace ShaTask.Services
{
    public class InvoiceHeaderAndInvoiceDetailsImpl : IInvoiceHeaderAndInvoiceDetailsService
    {
        private readonly ApplicationDbContext _context;
        public InvoiceHeaderAndInvoiceDetailsImpl(ApplicationDbContext context)
        {
            _context = context;
        }


       public IEnumerable<InvoiceHeaderAndDetailsDto> GetAllInvoices()
        {

            //return  _context.InvoiceDetails
            //     .Join(
            //         _context.InvoiceHeader,
            //         ID => ID.InvoiceHeaderId,
            //         IH => IH.Id,
            //         (ID, IH) => new { ID.InvoiceHeaderId, IH.CustomerName, IH.InvoiceDate, ID.ItemPrice }
            //          )
            //     .GroupBy(
            //              x => new { x.InvoiceHeaderId, x.CustomerName, x.InvoiceDate },
            //             (key, group) => new
            //             {
            //                 InvoiceHeaderId = key.InvoiceHeaderId,
            //                 CustomerName = key.CustomerName,
            //                 InvoiceDate = key.InvoiceDate,
            //                 TotalPrice = group.Sum(x => x.ItemPrice)
            //             }
            //             )
            //     .OrderBy(x => x.InvoiceHeaderId)
            //     .Select(dto => new InvoiceHeaderAndDetailsDto()
            //     {
            //         InvoiceHeaderId = dto.InvoiceHeaderId,
            //         CustomerName = dto.CustomerName,
            //         InvoiceDate = dto.InvoiceDate,
            //         TotalPrice = dto.TotalPrice
            //     }).ToList();





                    return  _context.InvoiceDetails
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
                            InvoiceHeaderId = joined.id.InvoiceHeaderId,
                            CustomerName = joined.ih.CustomerName,
                            InvoiceDate = joined.ih.InvoiceDate,
                            TotalPrice = joined.id.ItemPrice,
                            BranchName = joined.b.BranchName,
                            CashierName = joined.c.CashierName
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
                        grouped => new InvoiceHeaderAndDetailsDto()
                        {
                          InvoiceHeaderId=  grouped.Key.InvoiceHeaderId,
                          CustomerName=  grouped.Key.CustomerName,
                          InvoiceDate = grouped.Key.InvoiceDate,
                          TotalPrice = grouped.Sum(x => x.TotalPrice),
                          BranchName=    grouped.Key.BranchName,
                          CashierName= grouped.Key.CashierName
                        }
                    )
                    .OrderBy(result => result.InvoiceHeaderId)
                    .ToList();


        }
    }
}
