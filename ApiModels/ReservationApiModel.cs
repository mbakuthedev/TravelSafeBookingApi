using System.ComponentModel.DataAnnotations.Schema;
using TravelSafeBookingApi.DataModels;

namespace TravelSafeBookingApi.ApiModels
{
    public class ReservationApiModel : BaseApiModel
    {
        /// <summary>
        /// Foreign Key of the Customer
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Foreign key of the Bus
        /// </summary>
        public string BusId { get; set; }
    
    }
}
