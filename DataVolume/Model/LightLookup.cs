using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVolume.Model
{
    public class LightLookup
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string ColumnB { get; set; }

        [StringLength(50)]
        public string ColumnC { get; set; }

        [StringLength(128)]
        public string ColumnD { get; set; }
        
        public decimal ColumnF { get; set; }

        public decimal ColumnG { get; set; }

        public DateTime ColumnH { get; set; }

        public DateTime ColumnI { get; set; }
    }
}
