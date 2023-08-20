namespace TravelSafeBookingApi.ApiModels
{
    public class BusesApiModel : BaseApiModel
    {
        /// <summary>
        /// Seater capacity of the bus
        /// </summary>
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// Name of the bus
        /// </summary>
        public string BusName { get; set; }

        /// <summary>
        /// Description of the bus to be boarded
        /// </summary>
        public string BusDescription { get; set; }

        /// <summary>
        /// Colour of the bus
        /// </summary>
        public string BusColour { get; set; }

    }
}
