using System.ComponentModel.DataAnnotations.Schema;

namespace TravelSafeBookingApi.DataModels
{
    /// <summary>
    /// Bus routes are found here 
    /// </summary>
    public class BusRoutesDataModel : BaseDataModel
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
