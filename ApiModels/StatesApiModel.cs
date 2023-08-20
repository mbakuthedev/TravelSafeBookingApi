namespace TravelSafeBookingApi.ApiModels
{
    public class StatesApiModel : BaseApiModel
    {
        /// <summary>
        /// Name of the state passed through
        /// </summary>
        public string StateName { get; set; }
        /// <summary>
        /// Description of the state passed through
        /// </summary>
        public string StateDescription { get; set; }
        /// <summary>
        /// Tourist centers contained in the states
        /// </summary>
        public string TouristCenters { get; set; }
    }
}
