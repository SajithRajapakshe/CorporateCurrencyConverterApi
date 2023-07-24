using CorporateCurrencyConverterBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCurrencyConverterBL.Helpers
{
    /// <summary>
    /// Generic class for request operations
    /// </summary>
    public class RequestHelper : IRequestHelper
    {
        public double Convert(string ApiBaseUrl, string userName, string password, string baseCurrency, string targetCurrency,double inputAmount)
        {
            var response = GetResponse(ApiBaseUrl, userName, password);
            return 2.0;
        }

        /// <summary>
        /// Gets web response from API
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string GetResponse(string url, string userName, string password)
        {
            string jsonString;

            var request= CreateRequest(url, userName, password);

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream, Encoding.Default))
                {
                    jsonString = reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        jsonString = reader.ReadToEnd();
                    }
                }
            }

            return jsonString;
        }

        /// <summary>
        /// Creates web request.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static HttpWebRequest CreateRequest(string url, string userName, string password)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(userName + ":" + password);
            string val = System.Convert.ToBase64String(plainTextBytes);
            request.Headers.Add("Authorization", "Basic " + val);

            return request;
        }
    }
}
