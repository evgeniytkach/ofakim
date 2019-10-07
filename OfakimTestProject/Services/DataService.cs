using OfakimTestProject.DAL;
using OfakimTestProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace OfakimTestProject.Services
{
    public class DataService
    {

        public static MainModel GetMainModel()
        {
            try
            {
                using (var db = new DbOfakimContext())
                {
                    var model = new MainModel
                    {
                        CurrencyPairs = db.CurrencyPairs.ToList(),
                        CurrencySources = db.CurrencySources.ToList(),
                        CurrencyData = new List<CurrencyDataModel>()
                    };
                    var data = db.CurrencyData.GroupBy(x => new { x.SourceId, x.PairId }).Select(g => g.OrderByDescending(d => d.DateCreate)).ToList();
                    foreach (var d in data)
                    {
                        var lastData = d.FirstOrDefault();
                        if (lastData != null)
                            model.CurrencyData.Add(lastData);
                    }
                    return model;
                }
            }
            catch { }
            return null;
        }


        public static List<LogModel> GetData()
        {
            var log = new List<LogModel>();
            try
            {
                using (var db = new DbOfakimContext())
                {
                    foreach (var source in db.CurrencySources)
                        foreach (var pair in db.CurrencyPairs)
                        {
                            var cLog = new LogModel
                            {
                                DataModel = new CurrencyDataModel()
                                {
                                    PairId = pair.Id,
                                    SourceId = source.Id,
                                    DateCreate = HelpService.GetIsraelTime()
                                }
                            };
                            log.Add(cLog);
                            var value = ParseData.GetData(source, pair);
                            if (value != null)
                            {
                                cLog.DataModel.Value = (decimal)value;
                                cLog.LogMsg = InsertValue(cLog.DataModel) ? "Success" : "Error insert to db";
                            }
                            else
                                cLog.LogMsg = "Parse Error";
                        }
                }
            }
            catch
            {
                //Log
            }
            return log;
        }


        private static bool InsertValue(CurrencyDataModel data)
        {
            try
            {
                using (var db = new DbOfakimContext())
                {
                    db.CurrencyData.Add(data);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                //Log
            }
            return false;
        }

        //Keep only data for last 10 days
        public static void DeleteOldValues()
        {
            try
            {
                var oldDataTime = HelpService.GetIsraelTime().AddDays(-10);
                using (var db = new DbOfakimContext())
                {
                    db.CurrencyData.RemoveRange(db.CurrencyData.Where(x => x.DateCreate < oldDataTime));
                    db.SaveChanges();
                }
            }
            catch
            {
                //Log
            }
        }

    }
}