using System.Collections.Generic;


namespace OfakimTestProject.Models
{
    public class MainModel
    {
        public List<CurrencyDataModel> CurrencyData { set; get; }
        public List<CurrencyPairModel> CurrencyPairs { set; get; }
        public List<CurrencySourceDataModel> CurrencySources { set; get; }
    }
}