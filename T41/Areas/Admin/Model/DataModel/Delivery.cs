using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T41.Areas.Admin.Models.DataModel
{
    public class Delivery
    {
    }
    public class PostMan
    {
        public int POSTMAN_ID { get; set; }
        public string POSTMAN_NAME { get; set; }
    }
    public class DeliveryPostCode
    {
        public int POST_CODE { get; set; }
        public string POST_CODE_NAME { get; set; }
    }
    public class ComeDeliverySummary
    {
        public int COUNT { get; set; }
        public int TOTAL_WEIGHT { get; set; }
        public int TOTAL_AMOUNT { get; set; }
    }
    public class RemainDeliverySummary
    {
        public int COUNT { get; set; }
        public int TOTAL_WEIGHT { get; set; }
        public int TOTAL_AMOUNT { get; set; }
    }
    public class SuccessDeliverySummary
    {
        public int COUNT { get; set; }
        public int TOTAL_WEIGHT { get; set; }
        public int TOTAL_AMOUNT { get; set; }
    }
    public class UnSuccessDeliverySummary
    {
        public int COUNT { get; set; }
        public int TOTAL_WEIGHT { get; set; }
        public int TOTAL_AMOUNT { get; set; }
    }
    public class ReturnDeliverySummary
    {
        public int COUNT { get; set; }
        public int TOTAL_WEIGHT { get; set; }
        public int TOTAL_AMOUNT { get; set; }
    }
    public class DeliveryDetail
    {
        public string CHANNEL { get; set; }
        public string ID_PROCESS { get; set; }
        public string DELIVERY_DATE_TIME { get; set; }
        public string SYSTEM_DATE_TIME { get; set; }
        public string LADING_CODE { get; set; }
        public string SERVICE_TYPE { get; set; }
        public string COME_DATE { get; set; }
        public string REMAIN_DATE { get; set; }
        public string DELIVERY_RESULT { get; set; }
        public string REASON { get; set; }
        public string DELIVERY_PLACE { get; set; }
        public int FEE { get; set; }
        public int AMOUNT { get; set; }
        public int DELIVERY_POST_CODE { get; set; }
        public int DELIVERY_ROUTE_CODE { get; set; }
        public string POSTMAN_ID { get; set; }


    }
    public class ReturnDelivery
    {
        public string Code { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public int Total { get; set; }

        public DeliveryDetail DeliveryReport { get; set; }

        public List<DeliveryDetail> ListDeliveryReport;

        public MetaData MetaData { get; set; }


    }
    public class MetaData
    {
        public string from_to_date { get; set; }
        public string channel { get; set; }
        public string delivery_post_code { get; set; }
        public string delivery_route_code { get; set; }
        public string status { get; set; }
        public string postman { get; set; }
    }
    public class ReturnSummaryDelivery
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public ComeDeliverySummary ComeDeliverySummary;
        public RemainDeliverySummary RemainDeliverySummary;
        public SuccessDeliverySummary SuccessDeliverySummary;
        public UnSuccessDeliverySummary UnSuccessDeliverySummary;
        public ReturnDeliverySummary ReturnDeliverySummary;
        public MetaData MetaData { get; set; }
    }
}