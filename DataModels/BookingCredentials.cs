namespace TravelSafeBookingApi.DataModels
{
    public class BookingCredentials : BaseDataModel
    {
        /// <summary>
        /// The email of the customer
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The firstname of the firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The lastname of the customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The location where the customer leaves
        /// </summary>
        public string TravellingFrom { get; set; }

        /// <summary>
        /// The destination of the customer
        /// </summary>
        public string TravellingTo { get; set; }

        /// <summary>
        /// The phone number of the customer
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The title of the customer
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The  date the customer wants to leave
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// The id of the bus selected
        /// </summary>
        public string BusId { get; set; }


    }
}
