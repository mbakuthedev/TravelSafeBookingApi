using System.ComponentModel.DataAnnotations.Schema;

namespace TravelSafeBookingApi.DataModels
{
    public class PaymentTransactions : BaseDataModel
    {
        /// <summary>
        /// The customer id of the customer initiating the transaction
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// The order id of the customer
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// The payment status of the customer
        /// </summary>
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// The payment reference id of the customer
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// The foreign Key of the customer
        /// </summary>

        [ForeignKey(nameof(CustomerId))]
        public List<CustomerDataModel> Customers { get; set; }
    }
}
