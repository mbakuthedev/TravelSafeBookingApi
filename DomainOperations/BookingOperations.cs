using Microsoft.EntityFrameworkCore;
using System.Net;
using TravelSafeBookingApi.ApiModels.OperationResults;
using TravelSafeBookingApi.Data;
using TravelSafeBookingApi.DataModels;

namespace TravelSafeBookingApi.DomainOperations
{
    public class BookingOperations
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger _logger;
        public BookingOperations(ApplicationDbContext context,ILogger logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<OperationResult> InitializeBooking(BookingCredentials credentials)
        {
            // Initialize operation result
            OperationResult result;
            try
            {
                //  Check if the credentials and the Customer data model are the same
               var customers = await _context.Customers.FirstOrDefaultAsync( x => x.Email == credentials.Email);
                
                // check if the customer is null
                if (customers == null)
                {
                    // fill the customers from the credentials 
                    var newCustomers = new CustomerDataModel
                    {
                        Email = credentials.Email,
                        Firstname = credentials.FirstName,
                        Lastname = credentials.LastName,
                        TravellingFrom = credentials.TravellingFrom,
                        TravellingTo = credentials.TravellingTo,
                        Phone = credentials.PhoneNumber,
                        Gender = credentials.Gender,
                        Title = credentials.Title,
                        ArrivalDate = credentials.ArrivalDate,
                    };
                     
                    // Add them to the database
                    await _context.Customers.AddAsync(newCustomers);

                    // Save the changes
                    _context.SaveChanges();

                    // Fetch the price of where the customer is going
                   var routePrices =  await _context.BusRoutes.FirstOrDefaultAsync(x => x.To == credentials.TravellingTo);

                    // Fetch the bus 
                    var bus = await _context.Buses.FirstOrDefaultAsync(x => x.Id == credentials.BusId);
                    
                    // check if the destination exists
                    if (routePrices == null)
                    {
                        result = new OperationResult
                        {
                            ErrorMessage = "Route cant be found",
                            Status = (int)HttpStatusCode.NotFound
                        };
                    }
                    var newBookingOrder = new ReservationDataModel
                    {
                        Price = routePrices.Price,
                        PaymentStatus = PaymentStatus.Pending,
                        CustomerId = customers.Id,
                        ReservationId = Guid.NewGuid().ToString(),
                        BusId = bus.Id
                    };

                    // add the changes to db
                    await _context.Reservations.AddAsync(newBookingOrder);

                    // save the changes
                   await _context.SaveChangesAsync();

                   
                }
                result = new OperationResult
                {
                   // Result = 
                };

            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(message: ex.Message, ex);

                // Return error result
                result = new OperationResult
                {
                    ErrorTitle = "SYSTEM ERROR",
                    ErrorMessage = "Transaction could not be initiated",
                    Status = (int)HttpStatusCode.InternalServerError
                };
            }
            // return the result
            return result;
        }
    }
}
