namespace TravelSafeBookingApi.ApiModels
{
    public class BusRoutesApiModel
    {
        /// <summary>
        /// Where the customer leaves
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// The destination of the customer
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Bus route information
        /// </summary>
        public string RouteInfo { get; set; }

        /// <summary>
        /// Price of each trip 
        /// </summary>
       public float Price { get; set; }
    }
}
