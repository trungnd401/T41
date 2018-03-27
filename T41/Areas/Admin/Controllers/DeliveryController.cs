using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using T41.Areas.Admin.Common;
using T41.Areas.Admin.Data;
using T41.Areas.Admin.Models.DataModel;

namespace T41.Areas.Admin.Controllers
{
    public class DeliveryController : Controller
    {
        int page_size = int.Parse(ConfigurationManager.AppSettings["PAGE_SIZE"]);
        Convertion common = new Convertion();
        ApiRepository apiRepository = new ApiRepository();

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DeliveryDetailReport()
        {
            return View();
        }
        public JsonResult ListPostCode()
        {
            return Json(apiRepository.ListPostCode(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListDeliveryRouteByPostCode(int postcode)
        {
            return Json(apiRepository.ListDeliveryRoute(postcode), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListPostMan()
        {
            return Json(apiRepository.ListPostMan(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListDetailedDeliveryReport(int channel, int postman, int postcode, int deliveryroute, int status, string fromdate, string todate, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            ViewBag.currentPageIndex = currentPageIndex;
            ViewBag.PageSize = page_size;
            ReturnDelivery returndelivery = new ReturnDelivery();
            returndelivery = apiRepository.ListDeliveryReport(channel, postman, postcode, deliveryroute, status, common.DateToInt(fromdate), common.DateToInt(todate), page_size, currentPageIndex);
            ViewBag.total = returndelivery.Total;
            ViewBag.total_page = (returndelivery.Total + page_size - 1) / page_size;
            return View(returndelivery.ListDeliveryReport);
        }
        public ActionResult SummaryDeliveryReport(int channel, int postman, int postcode, int deliveryroute, int status, string fromdate, string todate)
        {
            ReturnSummaryDelivery returndelivery = new ReturnSummaryDelivery();
            returndelivery = apiRepository.SummaryDelivery(channel, postman, postcode, deliveryroute, status, common.DateToInt(fromdate), common.DateToInt(todate));
            ViewBag.ComeDeliveryTotal = returndelivery.ComeDeliverySummary;
            ViewBag.RemainDeliveryTotal = returndelivery.RemainDeliverySummary;

            ViewBag.SuccessDeliveryTotal = returndelivery.SuccessDeliverySummary;
            ViewBag.UnsuccessDeliveryTotal = returndelivery.UnSuccessDeliverySummary;
            ViewBag.ReturnDeliveryTotal = returndelivery.ReturnDeliverySummary;

            ViewBag.TotalDelivery = returndelivery.ComeDeliverySummary.COUNT + returndelivery.RemainDeliverySummary.COUNT;
            ViewBag.TotalWeight = returndelivery.ComeDeliverySummary.TOTAL_WEIGHT + returndelivery.RemainDeliverySummary.TOTAL_WEIGHT;
            ViewBag.TotalCollect = returndelivery.ComeDeliverySummary.TOTAL_AMOUNT + returndelivery.RemainDeliverySummary.TOTAL_AMOUNT;
            ViewBag.TotalCollected = returndelivery.SuccessDeliverySummary.TOTAL_AMOUNT;
            return View();
        }
    }
}