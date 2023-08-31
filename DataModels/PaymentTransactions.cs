using System.ComponentModel.DataAnnotations.Schema;

namespace TravelSafeBookingApi.DataModels
{
    public class PaymentTransactions : BaseDataModel
    {
        public string CustomerId { get; set; }

        public string OrderId { get; set; }

        public int PaymentVerified { get; set; }

        public string ReferenceId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public List<CustomerDataModel> Customers { get; set; }
    }
}
