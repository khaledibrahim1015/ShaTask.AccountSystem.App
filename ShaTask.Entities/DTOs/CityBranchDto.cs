using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Entities.DTOs
{
    public  class CityBranchDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
