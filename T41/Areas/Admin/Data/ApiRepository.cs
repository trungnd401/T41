using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T41.Areas.Admin.Models.DataModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Configuration;
namespace T41.Areas.Admin.Data
{
    public class ApiRepository
    {
        #region ListPostCode
        public List<DeliveryPostCode> ListPostCode()
        {
            List<DeliveryPostCode> lstPostCode = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["URI"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //var byteArray = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Username"] + ":" + ConfigurationManager.AppSettings["Password"]);
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var _response = client.GetAsync("api/Route").Result;
                    lstPostCode = _response.Content.ReadAsAsync<List<DeliveryPostCode>>().Result;
                }
            }
            catch (Exception ex)
            {
                // LogAPI.LogToFile(LogFileType.EXCEPTION, "ApiRepository.Post_E1E2_DS: " + ex.Message);              
            }
            return lstPostCode;
        }
        #endregion

        #region ListDeliveryRoute
        public List<DeliveryPostCode> ListDeliveryRoute(int postcode)
        {
            List<DeliveryPostCode> lstPostCode = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["URI"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //var byteArray = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Username"] + ":" + ConfigurationManager.AppSettings["Password"]);
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var _response = client.GetAsync("api/Route?id=" + postcode).Result;
                    lstPostCode = _response.Content.ReadAsAsync<List<DeliveryPostCode>>().Result;
                }
            }
            catch (Exception ex)
            {
                // LogAPI.LogToFile(LogFileType.EXCEPTION, "ApiRepository.Post_E1E2_DS: " + ex.Message);              
            }
            return lstPostCode;
        }
        #endregion

        #region ListPostMan
        public List<PostMan> ListPostMan()
        {
            List<PostMan> lstPostMan = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["URI"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //var byteArray = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Username"] + ":" + ConfigurationManager.AppSettings["Password"]);
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var _response = client.GetAsync("api/Postman").Result;
                    lstPostMan = _response.Content.ReadAsAsync<List<PostMan>>().Result;
                }
            }
            catch (Exception ex)
            {
                // LogAPI.LogToFile(LogFileType.EXCEPTION, "ApiRepository.Post_E1E2_DS: " + ex.Message);              
            }
            return lstPostMan;
        }
        #endregion

        #region ListDeliveryReport
        public ReturnDelivery ListDeliveryReport(int channel, int postman, int postcode, int deliveryroute, int status, int fromdate, int todate, int page_size, int page_index)
        {
            ReturnDelivery returndelivery = new ReturnDelivery();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["URI"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //var byteArray = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Username"] + ":" + ConfigurationManager.AppSettings["Password"]);
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var _response = client.GetAsync("api/Delivery?channel=" + channel + "&&postman=" + postman + "&&status=" + status + "&&from_date=" + fromdate + "&&to_date=" + todate + "&&delivery_post_code=" + postcode + "&&delivery_route_code=" + deliveryroute + "&&page_size=" + page_size + "&&page_index=" + page_index).Result;
                    returndelivery = _response.Content.ReadAsAsync<ReturnDelivery>().Result;
                }
            }
            catch (Exception ex)
            {
                // LogAPI.LogToFile(LogFileType.EXCEPTION, "ApiRepository.Post_E1E2_DS: " + ex.Message);              
            }
            return returndelivery;
        }
        #endregion

        #region SummaryComeDelivery
        public ReturnSummaryDelivery SummaryDelivery(int channel, int postman, int postcode, int deliveryroute, int status, int fromdate, int todate)
        {
            ReturnSummaryDelivery summarydelivery = new ReturnSummaryDelivery();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["URI"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //var param = "api/Delivery?channel = " + channel + "&&postman = " + postman + "&&status = " + status + "&&from_date = " + fromdate + "&&to_date = " + todate + "&&delivery_post_code = " + postcode + "&&delivery_route_code = " + deliveryroute;
                    //var byteArray = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Username"] + ":" + ConfigurationManager.AppSettings["Password"]);
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var _response = client.GetAsync("api/Delivery?channel=" + channel + "&&postman=" + postman + "&&status=" + status + "&&from_date=" + fromdate + "&&to_date=" + todate + "&&delivery_post_code=" + postcode + "&&delivery_route_code=" + deliveryroute).Result;
                    summarydelivery = _response.Content.ReadAsAsync<ReturnSummaryDelivery>().Result;
                }
            }
            catch (Exception ex)
            {
                // LogAPI.LogToFile(LogFileType.EXCEPTION, "ApiRepository.Post_E1E2_DS: " + ex.Message);              
            }
            return summarydelivery;
        }
        #endregion
    }
}