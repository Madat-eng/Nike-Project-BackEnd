using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class DTOPayment
    {
        public DTOPayment(int paymentID, DTOOrder order, DTOUser user, decimal amount, string paymentMethod, string paymentStatus, string transactionID, DateTime paymentDate, string currency, string cardLastFour, string paymentGatway, bool isRefunded, decimal remainingAmount, string failurReason, DateTime refundDate, string iPAddress)
        {
            PaymentID = paymentID;
            Order = order;
            User = user;
            Amount = amount;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
            TransactionID = transactionID;
            PaymentDate = paymentDate;
            Currency = currency;
            CardLastFour = cardLastFour;
            PaymentGatway = paymentGatway;
            IsRefunded = isRefunded;
            RemainingAmount = remainingAmount;
            FailurReason = failurReason;
            RefundDate = refundDate;
            IPAddress = iPAddress;
        }

        public int PaymentID { get; set; }
        public DTOOrder Order { get; set; }
        public DTOUser User { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string TransactionID { get; set; }
        public DateTime PaymentDate { get; set; }

        public string Currency { get; set; }

        public string CardLastFour { get; set; }
        public string PaymentGatway { get; set; }
        public bool IsRefunded { get; set; }
        public decimal RemainingAmount { get; set; }
        public string FailurReason { get; set; }
        public DateTime RefundDate { get; set; }
        public string IPAddress { get; set; }

    }
}
