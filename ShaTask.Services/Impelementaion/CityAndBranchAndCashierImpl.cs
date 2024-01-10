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
    public class CityAndBranchAndCashierImpl : ICityAndBranchAndCashierService
    {
        private readonly ApplicationDbContext _context;

        public CityAndBranchAndCashierImpl(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Fisrt Render to Get All Cities In db 
        /// </summary>
        /// <returns>IEnumerable<City></returns>
        public IEnumerable<City> GetCitiesDDL()
            => _context.Cities.ToList();

        /// <summary>
        /// To Get All Branches Based On City that Pass! 
        /// </summary>
        /// <param name="CityId"></param>
        /// <returns></returns>
        public IQueryable<BranchDto> GetBranchesDDL(int CityId)
            => _context.Branches
               .Where(b => b.CityId == CityId)
               .Select(b => new BranchDto() { Id = b.Id , BranchName = b.BranchName });


        /// <summary>
        /// To Get All Cashier Based On Branch that Pass! 
        /// </summary>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        public IQueryable<CashierDto> GetCashiersDDL(int BranchId)
            => _context.Cashier
                       .Where(c => c.BranchId ==BranchId)
                       .Select(c=> new CashierDto() { Id=c.Id, CashierName=c.CashierName});

        /// <summary>
        /// To Get Join Data between City And Branches 
        /// </summary>
        /// <param name="CityId"></param>
        /// <returns></returns>
        public IQueryable<CityBranchDto> GetCityBranchesData(int CityId)
        {
             return _context.Branches
                                   .Join(
                                         _context.Cities,
                                         branch => branch.CityId,
                                         city => city.Id,
                                         (branch, city) => new CityBranchDto
                                            {
                                                CityId = city.Id,
                                                CityName = city.CityName,
                                                BranchId = branch.Id,
                                                BranchName = branch.BranchName

                                            }
                                         )
                                     .Where(c => c.CityId == CityId);
        }

        public IQueryable<BranchCashierDto> GetBranchCashiersData(int BranchId)
        {
            return  _context.Cashier
                                    .Join(
                                          _context.Branches,
                                          cashier => cashier.BranchId,
                                          branch => branch.Id,
                                          (cashier, branch) => new BranchCashierDto
                                          {
                                                BranchId = branch.Id,
                                                BranchName = branch.BranchName,
                                                CashierId = cashier.Id,
                                                CashierName =cashier.CashierName
                                          }
                                          )
                                      .Where(branch => branch.BranchId == BranchId);


        }







    }
}
