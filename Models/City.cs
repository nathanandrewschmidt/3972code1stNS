using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace nsCode1st.Models
{
    public class City
    {
        [Key]
        [MaxLength(30)]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int Population { get; set; }

        public string ProvinceCode { get; set; }
        [ForeignKey("ProvinceCode")]
        public Province Team { get; set; }
    }
}
