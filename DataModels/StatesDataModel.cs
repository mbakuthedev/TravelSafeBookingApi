namespace TravelSafeBookingApi.DataModels
{
    /// <summary>
    /// Information about states to be passed are here
    /// </summary>
    public class StatesDataModel : BaseDataModel
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
