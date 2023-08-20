namespace TravelSafeBookingApi.DataModels
{
    /// <summary>
    /// Information about the buses are here
    /// </summary>
    public class BusesDataModel: BaseDataModel
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
