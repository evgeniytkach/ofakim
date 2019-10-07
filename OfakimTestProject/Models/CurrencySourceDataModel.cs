using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfakimTestProject.Models
{
    [Table("CurrencySourceData")]
    public class CurrencySourceDataModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string XPath { get; set; }
    }
}