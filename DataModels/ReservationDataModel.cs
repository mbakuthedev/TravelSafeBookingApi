using System.ComponentModel.DataAnnotations.Schema;

namespace TravelSafeBookingApi.DataModels
{

    /// <summary>
    /// Reservation data is found here 
    /// </summary>
    public class ReservationDataModel : BaseDataModel
    {
        /// <summary>
        /// Foreign Key of the Customer
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Foreign key of the Bus
        /// </summary>
        public string  BusId { get; set; }

        /// <summary>
        /// The Price of the order
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// The reservation id of the bus reservation
        /// </summary>
        public string ReservationId { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// Customer Information for booking
        /// </summary>
        [ForeignKey(nameof(CustomerId))]
        public CustomerDataModel Customer { get; set; }

        /// <summary>
        /// Foreign Key of the Buses
        /// </summary>
        [ForeignKey(nameof(BusId))]
        public BusesDataModel Buses { get; set; }

    }
    public enum PaymentStatus
    {
        Pending,
        Initialized,
        Completed
    }
}
