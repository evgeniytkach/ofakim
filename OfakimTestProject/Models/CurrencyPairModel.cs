using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfakimTestProject.Models
{
    [Table("CurrencyPairs")]
    public class CurrencyPairModel
    {
        [Key]
        public int Id { get; set; }

        public string Code1 { get; set; }

        public string Code2 { get; set; }
    }
}