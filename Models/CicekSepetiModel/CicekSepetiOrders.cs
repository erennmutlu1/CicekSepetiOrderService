using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiOrderService.Models.CicekSepetiModel
{
    public class CicekSepetiOrders
    {
        [Key]
        public Int64 erry { get; set; }
        public Int64 branchId { get; set; }
        public Int64 customerId { get; set; }
        public string accountCode { get; set; }
        public string accountCodePrefix { get; set; }
        public Int64 orderId { get; set; }
        public Int64 orderItemId { get; set; }
        public DateTime orderCreateDate { get; set; }
        public float cargoPrice { get; set; }
        public string orderCreateTime { get; set; }
        public DateTime orderModifyDate { get; set; }
        public string orderModifyTime { get; set; }
        public string barcode { get; set; }
        public string cardMessage { get; set; }
        public string cardName { get; set; }
        public float deliveryCharge { get; set; }
        public string orderPaymentType { get; set; }
        public Int64 orderItemStatusId { get; set; }
        public string orderProductStatus { get; set; }
        public string orderItemTextListModel { get; set; } 
        public float discount { get; set; }
        public float totalPrice { get; set; }
        public float tax { get; set; }
        public string receiverName { get; set; }
        public string receiverPhone { get; set; }
        public string receiverAddress { get; set; }
        public string deliveryType { get; set; }
        public DateTime deliveryDate { get; set; }
        public DateTime requestedDeliveryDate { get; set; }
        public string cargoCompany { get; set; }
        public string receiverCity { get; set; }
        public string receiverRegion { get; set; }
        public string receiverDistrict { get; set; }
        public string senderName { get; set; }
        public string? senderAddress { get; set; }
        public Int64? senderTaxNumber { get; set; }
        public string? senderTaxOfficeName { get; set; }
        public string senderCity { get; set; }
        public string senderRegion { get; set; }
        public string senderDistrict { get; set; }
        public string cargoNumber { get; set; }
        public string? shipmentTrackingUrl { get; set; }
        public Int64 productId { get; set; }
        public string productCode { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public Int64 quantity { get; set; }
        public string quantityUnit { get; set; }
        public string invoiceEmail { get; set; }
        public string isOrderStatusActive { get; set; }
        public string partialNumber { get; set; }
        public string? senderCompanyName { get; set; }
        public float allowanceRate { get; set; }
        public float credit { get; set; }
        public string? deliveryOptionName { get; set; }
        public string deliveryTime { get; set; }
        public string cancellationResult { get; set; }
        public string isFloristCargoOrder { get; set; }
        public string? receiverCompanyName { get; set; }
        public string floristName { get; set; }
        public string floristAddress { get; set; }
        public string isLateToCargo { get; set; }




    }
}
