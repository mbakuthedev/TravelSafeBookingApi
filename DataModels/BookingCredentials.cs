namespace TravelSafeBookingApi.DataModels
{
    public class BookingCredentials : BaseDataModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TravellingFrom { get; set; }
        public string TravellingTo { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public DateTime ArrivalDate { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string BusId { get; set; }

    }
}
