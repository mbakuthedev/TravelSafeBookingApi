using System.ComponentModel.DataAnnotations.Schema;

namespace TravelSafeBookingApi.DataModels
{
    public class CustomerDataModel : BaseDataModel
    {
        /// <summary>
        /// Customers Firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Customers Lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Customers Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Customers Phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Where the customer is travelling from
        /// </summary>
        public string TravellingFrom { get; set; }

        /// <summary>
        /// Where the Customer is Travelling to
        /// </summary>
        public string TravellingTo { get; set; }

        /// <summary>
        /// Arrival Date of the Customer
        /// </summary>
        public DateTime DepatureDate { get; set; }

        /// <summary>
        /// The title of the customer
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The gender of the customer
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// The foreign key of the bus
        /// </summary>
        public string BusId { get; set; }

        /// <summary>
        /// The bus information of the customer
        /// </summary>
        [ForeignKey(nameof(BusId))]
        public BusesDataModel BusOrder { get; set; }


    }

    public enum Gender
    {
        Male = 0,
        Female = 1 
    }
}
