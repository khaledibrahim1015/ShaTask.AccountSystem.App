using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Entities.DTOs
{
    public class BranchCashierDto
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int CashierId { get; set; }
        public string CashierName { get; set; }
    }

}
