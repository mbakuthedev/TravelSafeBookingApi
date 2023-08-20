using Microsoft.EntityFrameworkCore;
using System.Net;
using TravelSafeBookingApi.ApiModels;
using TravelSafeBookingApi.ApiModels.OperationResults;
using TravelSafeBookingApi.Data;
using TravelSafeBookingApi.DataModels;

namespace TravelSafeBookingApi.DomainOperations
{
    public class BusOperations
    {
        /// <summary>
        /// Scoped instance of the db context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Scoped instance of the logger
        /// </summary>
        private readonly ILogger<BusOperations> _logger;

        /// <summary>
        /// Constructor for DI
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public BusOperations(ApplicationDbContext context, ILogger<BusOperations> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OperationResult> CreateBuses(BusesApiModel model)
        {
            // Initialize operation result
            OperationResult result;
            try
            {
                // Create buses 
                var buses = new BusesDataModel
                {
                    BusName = model.BusName,
                    BusDescription = model.BusDescription,
                    BusColour = model.BusColour,
                    NumberOfSeats = model.NumberOfSeats
                };
                await _context.Buses.AddAsync(buses);
                _context.SaveChanges();

                result = new OperationResult
                {
                    Result = new { buses }
                };
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError($"An error occured: {ex.Message}");

                result = new OperationResult
                {
                    ErrorMessage = " A server error occured",
                    Status = (int)HttpStatusCode.InternalServerError
                };
            }
            return result;
        }
        public async Task<OperationResult> EditBuses(string id, BusesApiModel model)
        {
            OperationResult result;

            try
            {
                var buses = await _context.Buses.FirstOrDefaultAsync(x => x.Id == id);
                if (buses == null)
                {
                    result = new OperationResult
                    {
                        ErrorMessage = "Not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }

                buses.BusName = model.BusName;
                buses.BusDescription = model.BusDescription;
                buses.BusColour = model.BusColour;
                _context.Buses.Update(buses);
                await _context.SaveChangesAsync();

                result = new OperationResult
                {
                    Result = new { buses }
                };
            }
            catch (Exception ex)
            {

                _logger.LogError($"An error occured: {ex.Message}");
                result = new OperationResult
                {
                    ErrorMessage = " A server error occured",
                    Status = (int)HttpStatusCode.InternalServerError
                };
            }
            return result;
        }
        public async Task<IEnumerable<BusesDataModel>> FetchBuses()
        {
            return await _context.Buses.ToListAsync();
        }
        public async Task<OperationResult> FetchBusesById(string id)
        {
            OperationResult result;
            try
            {
                var buses = await _context.Buses.FirstOrDefaultAsync(x => x.Id == id);
                if (buses == null)
                {
                    result = new OperationResult
                    {
                        ErrorMessage = "Not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }
                result = new OperationResult
                {
                    Result = new { buses }
                };

            }
            catch (Exception ex)
            {

                _logger.LogError($"An error occured: {ex.Message}");
                result = new OperationResult
                {
                    ErrorMessage = " A server error occured",
                    Status = (int)HttpStatusCode.InternalServerError
                };
            }

            return result;
        }

        public async Task<OperationResult> FetchBusesByName(BusesApiModel model)
        {
            OperationResult result;
            try
            {
                var buses = await _context.Buses.FirstOrDefaultAsync(x => x.Id == model.BusName);
                if (buses == null)
                {
                    result = new OperationResult
                    {
                        ErrorMessage = "Not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }
                return result = new OperationResult
                {
                    Result = new { buses }
                };
            }
            catch (Exception ex)
            {

                _logger.LogError($"An error occured: {ex.Message}");
                result = new OperationResult
                {
                    ErrorMessage = " A server error occured",
                    Status = (int)HttpStatusCode.InternalServerError
                };
                return result;
            }
        }
        public async Task<OperationResult> DeleteBus(string id)
        {
            // Initialize the operation result
            OperationResult result;
            try
            {
                // This selects the id from the database
                var buses = await _context.Buses.FindAsync(id);

                // This performs a null check
                if (buses == null)
                {
                    // Return an error
                    return new OperationResult
                    {
                        ErrorMessage = "Id not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }
                // Remove the record from the database 
                _context.Buses.Remove(buses);

                // Return a no content result
                result = new OperationResult
                {
                    Result = "Record deleted sucessfully",
                    Status = (int)HttpStatusCode.NoContent
                };
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError($"An error occured : {ex.Message}");

                // Return a custom error
                result = new OperationResult
                {
                    ErrorMessage = " A server error occured",
                    Status = (int)HttpStatusCode.InternalServerError
                };
            }
            return result;
        }
    }
}
