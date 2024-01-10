using ShaTask.Entities.DTOs;
using ShaTask.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Services
{
    public  interface ICityAndBranchAndCashierService
    {
        IEnumerable<City> GetCitiesDDL();
        IQueryable<BranchDto> GetBranchesDDL(int CityId);
        IQueryable<CashierDto> GetCashiersDDL(int BranchId);
        IQueryable<CityBranchDto> GetCityBranchesData(int CityId);
        IQueryable<BranchCashierDto> GetBranchCashiersData(int BranchId);



    }
}
