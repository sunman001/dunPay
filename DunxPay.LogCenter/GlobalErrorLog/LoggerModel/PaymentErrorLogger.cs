using System;
using DunxPay.LogCenter.DxLogDomain;
using DunxPay.LogCenter.EnumHelper;
using DunxPay.LogCenter.Extensions;


namespace DunxPay.LogCenter.GlobalErrorLog.LoggerModel
{
    public class PaymentErrorLogger : ErrorLoggerManger, IErrorLogger
    {
        protected DxPayLogError DxpayLogError;

        public  PaymentErrorLogger(int UserId)
        {
            DxpayLogError = new DxPayLogError
            {
                CreatedOn = DateTime.Now,
                UserId = UserId,
                IpAddress = RequestHelper.GetClientIp(),
                TypeValue = 1
            };
            throw new Exception();
        }
        public void Logger(string message, string location = "", string summary = "")
        {
            DxpayLogError.Message = message;
            DxpayLogError.Location = location;
            DxpayLogError.Summary = summary;
            DxpayLogError.ClientId = (int) DxClient.Payment;
            DxpayLogError.ClientName = DxClient.Payment.GetDescription();
            errorLoggerWriter.Writer(DxpayLogError);
        }
    }
}
