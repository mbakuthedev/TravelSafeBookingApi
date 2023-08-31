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
                        Title = credentials.Title,
                        DepatureDate = credentials.DepartureDate,
                        BusId = credentials.BusId
                    };

                    // Add them to the database
                    await _context.Customers.AddAsync(newCustomers);

                    // Save the changes
                    _context.SaveChanges();
                }

                    // Fetch the price of where the customer is going
                   var routePrices =  await _context.BusRoutes.FirstOrDefaultAsync(x => x.To == credentials.TravellingTo);
                    
                    // check if the destination exists
                    if (routePrices == null)
                    {
                        result = new OperationResult
                        {
                            ErrorMessage = "Route cant be found",
                            Status = (int)HttpStatusCode.NotFound
                        };
                    }
                    
                    // create a reservation id
                    var reservationId = Guid.NewGuid().ToString();

                    // create a new booking id 
                    var newBookingOrder = new ReservationDataModel
                    {
                        Price = routePrices.Price,
                        PaymentStatus = PaymentStatus.Pending,
                        CustomerId = customers.Id,
                        ReservationId = reservationId,
                        BusId = credentials.BusId
                    };

                    // add the changes to db
                    await _context.Reservations.AddAsync(newBookingOrder);

                    // save the changes
                   await _context.SaveChangesAsync();
                    
                // return the result
                result = new OperationResult
                {
                   Result = reservationId
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

        public async Task<OperationResult> ReserveBus(string reservationId)
        {
            // Initialize operation result
            OperationResult result;

            try
            {
              var custReservation = await _context.Reservations.FirstOrDefaultAsync(x => x.ReservationId == reservationId);
                if (custReservation == null)
                {
                    result = new OperationResult
                    {
                        ErrorMessage = "The reservation Id does not exist",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }
                else
                {
                    // update the reservations
                    var newReservationDetails = new ReservationDataModel
                    {
                        PaymentStatus = PaymentStatus.Initialized,
                    };

                    // update the reservation details
                    _context.Reservations.Update(newReservationDetails);

                    // initialize payments transactions
                    var payments = new PaymentTransactions
                    {
                        CustomerId = custReservation.CustomerId,
                        OrderId = custReservation.ReservationId,
                        //ReferenceId = Guid.NewGuid().ToString(),
                        PaymentStatus = PaymentStatus.Initialized
                    };

                    // commit the changes to the database
                    _context.Payments.Update(payments);

                    // update the database
                    _context.SaveChanges();


                }

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
        }
    }
}
