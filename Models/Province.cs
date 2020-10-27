using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nsCode1st.Models
{
    public class Province
    {
        [Key]
        [MaxLength(30)]
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public List<City> Citites { get; set; }
    }
}
