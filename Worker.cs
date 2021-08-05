using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CicekSepetiOrderService.DBContext;
using CicekSepetiOrderService.Context;
using CicekSepetiOrderService.Models.CicekSepetiModel;

namespace CicekSepetiOrderService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                string xApiKey = "";


                var client = new RestClient("https://apis.ciceksepeti.com/api/v1/Order/GetOrders");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("x-api-key", $"{xApiKey}");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "\r\n{\r\n  \"startDate\": \"2021-03-11T03:52:09.390Z\",\r\n  \"endDate\": \"2021-03-24T03:52:09.390Z\",\r\n  \"pageSize\": 100,\r\n  \"page\": 0,\r\n  \"statusId\":7\r\n\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);


                try
                {
                CiceksepetiOrderContext.CicekSepetiOrders deserializedCiceksepetiResponse = JsonConvert.DeserializeObject<CiceksepetiOrderContext.CicekSepetiOrders>(response.Content);



                    var order = new CicekSepetiOrders();

                    using (var dbContext = new CicekSepetiDBContext())
                    {

                        foreach (var content in deserializedCiceksepetiResponse.supplierOrderListWithBranch)
                        {

                            if (!dbContext.CicekSepetiOrders.Any(a => a.customerId == content.customerId))
                            {


                                try
                                {

                                
                                order = new CicekSepetiOrders();
                                _ = dbContext.Add(new CicekSepetiOrders
                                {
                                    branchId=content.branchId,
                                    customerId=content.customerId,
                                    accountCode=content.accountCode,
                                    accountCodePrefix=content.accountCodePrefix,
                                    orderId=content.orderId,
                                    orderItemId=content.orderItemId,
                                    orderCreateDate=Convert.ToDateTime(content.orderCreateDate),
                                    cargoPrice=content.cargoPrice,
                                    orderCreateTime=content.orderCreateTime,
                                    orderModifyDate= Convert.ToDateTime(content.orderModifyDate),
                                    orderModifyTime=content.orderModifyTime,
                                    barcode=content.barcode,
                                    cardMessage=content.cardMessage,
                                    cardName=content.cardName,
                                    deliveryCharge=content.deliveryCharge,
                                    orderPaymentType=content.orderPaymentType,
                                    orderItemStatusId=content.orderItemStatusId,
                                    orderProductStatus=content.orderProductStatus,
                                    orderItemTextListModel= null, 
                                    discount=content.discount,
                                    totalPrice=content.totalPrice,
                                    tax=content.tax,
                                    receiverName=content.receiverName,
                                    receiverPhone=content.receiverPhone,
                                    receiverAddress=content.receiverAddress,
                                    deliveryType=content.deliveryType,
                                    deliveryDate= Convert.ToDateTime(content.deliveryDate),
                                    requestedDeliveryDate= Convert.ToDateTime(content.requestedDeliveryDate),
                                    cargoCompany=content.cargoCompany,
                                    receiverCity=content.receiverCity,
                                    receiverRegion=content.receiverRegion,
                                    receiverDistrict=content.receiverDistrict,
                                    senderName=content.senderName,
                                    senderAddress=content.senderAddress,
                                    senderTaxNumber=content.senderTaxNumber,
                                    senderTaxOfficeName=content.senderTaxOfficeName,
                                    senderCity=content.senderCity,
                                    senderRegion=content.senderRegion,
                                    senderDistrict=content.senderDistrict,
                                    cargoNumber=content.cargoNumber,
                                    productId=content.productId,
                                    productCode=content.productCode,
                                    code=content.code,
                                    name=content.name,
                                    quantity=content.quantity,
                                    quantityUnit=content.quantityUnit,
                                    invoiceEmail=content.invoiceEmail,
                                    isOrderStatusActive=content.isOrderStatusActive,
                                    partialNumber=content.partialNumber,
                                    senderCompanyName=content.senderCompanyName,
                                    allowanceRate=content.allowanceRate,
                                    credit=content.credit,
                                    deliveryOptionName=content.deliveryOptionName,
                                    deliveryTime=content.deliveryTime,
                                    cancellationResult=content.cancellationResult,
                                    isFloristCargoOrder=content.isFloristCargoOrder,
                                    receiverCompanyName=content.receiverCompanyName,
                                    floristName=content.floristName,
                                    floristAddress=content.floristAddress,
                                    isLateToCargo=content.isLateToCargo








                                });
                                dbContext.SaveChanges();

                                }
                                catch (Exception ex)
                                {

                                    throw;
                                }
                                order.customerId = content.customerId;

                               
                               

                          
                             
                            }

                        }
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }



                _logger.LogInformation(response.Content);
                 Console.WriteLine(response.Content);

                await Task.Delay(10*1000, stoppingToken);
            }
        }
    }
}
