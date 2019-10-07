using HtmlAgilityPack;
using OfakimTestProject.Models;
using System.IO;
using System.Net;
using System.Text;

namespace OfakimTestProject.Services
{
    public class ParseData
    {

        private static string GetPage(string href, Encoding encoding)
        {
            string pageHtml = null;
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(href);
                request.Method = "GET";
                request.AllowAutoRedirect = true;
                request.CookieContainer = new CookieContainer();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), encoding))
                    pageHtml = sr.ReadToEnd();
            }
            catch
            {
                //Log
            }
            return pageHtml;
        }



        public static decimal? GetData(CurrencySourceDataModel source, CurrencyPairModel pair)
        {
            try
            {
                var doc = new HtmlDocument();
                var url = source.Url.Replace("{Code1}", pair.Code1).Replace("{Code2}", pair.Code2);
                var html = GetPage(url, Encoding.UTF8);
                doc.LoadHtml(html);
                foreach (var data in doc.DocumentNode.SelectNodes(source.XPath))
                {
                    if (decimal.TryParse(HelpService.GetDecimalStr(data.InnerText), out decimal value))
                        return value;
                }
            }
            catch
            {
                //Log
            }
            return null;
        }

    }
}