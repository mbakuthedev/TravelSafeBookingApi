using TravelSafeBookingApi.DataModels;

namespace TravelSafeBookingApi.ApiModels
{
    public class CustomerApiModel : BaseApiModel
    {
        /// <summary>
        /// Customers Firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Customers Lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Customers Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Customers Phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Where the customer is travelling from
        /// </summary>
        public string TravellingFrom { get; set; }

        /// <summary>
        /// Where the Customer is Travelling to
        /// </summary>
        public string TravellingTo { get; set; }

        /// <summary>
        /// Arrival Date of the Customer
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Customers List of Reservations
        /// </summary>
        public List<ReservationDataModel> Reservations { get; set; }
    }
}
