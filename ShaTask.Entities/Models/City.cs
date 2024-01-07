using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaTask.Entities.Models
{
    /// <summary>
    ///  Models/City.cs
    /// </summary>
    public class City
    {

        public int Id { get; set; }
        public string CityName { get; set; }

        // Navigation Property 
        public List<Branch> Branches { get; set; }

    }


}
