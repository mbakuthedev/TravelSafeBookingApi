using System.ComponentModel.DataAnnotations.Schema;

namespace TravelSafeBookingApi.DataModels
{
    /// <summary>
    /// Bus routes are found here 
    /// </summary>
    public class BusRoutesDataModel : BaseDataModel
    {
        /// <summary>
        /// Bus route title
        /// </summary>
        public string RouteTitle { get; set; }

        /// <summary>
        /// Bus route information
        /// </summary>
        public string  RouteInfo { get; set; }

        /// <summary>
        /// The Id of the states the bus passes through
        /// </summary>
        public string StateId { get; set; }

        /// <summary>
        /// Price of each trip 
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// States relational datamodel
        /// </summary>
        [ForeignKey(nameof(StateId))]
        public List<StatesDataModel> States { get; set; }
        
      
    }
}
