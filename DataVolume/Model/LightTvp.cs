using System.ComponentModel.DataAnnotations;

namespace DataVolume.Model
{
    public class LightTvp
    {
        public int RepeatableId { get; set; }

        [StringLength(255)]
        public string ColumnA { get; set; }

        [StringLength(2000)]
        public string ColumnE { get; set; }
    }
}
