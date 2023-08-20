namespace TravelSafeBookingApi.ApiModels
{
    public class BusRoutesApiModel
    {
        /// <summary>
        /// Bus route title
        /// </summary>
        public string RouteTitle { get; set; }
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
