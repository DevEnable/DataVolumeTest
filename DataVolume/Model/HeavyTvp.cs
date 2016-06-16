using System;
using System.ComponentModel.DataAnnotations;

namespace DataVolume.Model
{
    public class HeavyTvp
    {
        [StringLength(255)]
        public string ColumnA { get; set; }

        [StringLength(255)]
        public string ColumnB { get; set; }

        [StringLength(50)]
        public string ColumnC { get; set; }

        [StringLength(128)]
        public string ColumnD { get; set; }

        [StringLength(2000)]
        public string ColumnE { get; set; }

        public decimal ColumnF { get; set; }

        public decimal ColumnG { get; set; }

        public DateTime ColumnH { get; set; }

        public DateTime ColumnI { get; set; }
    }
}
