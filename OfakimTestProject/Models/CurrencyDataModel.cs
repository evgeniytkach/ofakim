using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfakimTestProject.Models
{
    [Table("CurrencyData")]
    public class CurrencyDataModel
    {
        [Key]
        public int Id { get; set; }

        public int PairId { get; set; }

        public int SourceId { get; set; }

        public decimal Value { get; set; }

        public DateTime DateCreate { get; set; }
    }
}