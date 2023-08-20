using Microsoft.EntityFrameworkCore;
using System.Net;
using TravelSafeBookingApi.ApiModels;
using TravelSafeBookingApi.ApiModels.OperationResults;
using TravelSafeBookingApi.Data;
using TravelSafeBookingApi.DataModels;

namespace TravelSafeBookingApi.DomainOperations
{
    public class RouteOperation
    {
        /// <summary>
        /// Scoped instance of application db context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Scoped instance of Logger
        /// </summary>
        private readonly ILogger<RouteOperation> _logger;

        /// <summary>
        /// Constructor for DI
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public RouteOperation(ApplicationDbContext context, ILogger<RouteOperation> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// This creates the routes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OperationResult> CreateRoutes(BusRoutesApiModel model)
        {
            // Set a default variable for operation result
            OperationResult operation;
            try
            {
                // Fire the transaction
                var routes = new BusRoutesDataModel
                {
                    RouteTitle = model.RouteTitle,
                    RouteInfo = model.RouteInfo
                };

                // Check if the values are null
                if (routes == null)
                {
                    // Return error
                    operation = new OperationResult
                    {
                        ErrorMessage = "No information entered"
                    };
                }

                // Add to database
                await _context.BusRoutes.AddAsync(routes);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Return the result
                operation =  new OperationResult
                {
                    Result = new { routes }
                };
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError($"Error occured : {ex.Message}");

                // Return a custom error
                operation = new OperationResult
                {
                    ErrorMessage = "A system error occured",
                    Status = (int)HttpStatusCode.InternalServerError
                };
            }

            // Return the operation
            return operation;
        }

        /// <summary>
        /// This function gets all the bus routes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BusRoutesDataModel>> GetAllRoutes()
        {
            return await _context.BusRoutes.ToListAsync();
        }

        /// <summary>
        /// This function gets a bus route by the selected id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OperationResult> GetRoutesById(string id)
        {
            // Initialize operation result
            OperationResult result;
            try
            {
                // Fetch the bus route from the database by the selected id
                var busRoute = await _context.BusRoutes.FirstOrDefaultAsync(x => x.Id == id);

                // Perform a null check on the bus routes
                if (busRoute == null)
                {
                    // Return an error if record is empty
                    return new OperationResult
                    {
                        ErrorMessage = " Not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }
                // Return the result
                result = new  OperationResult
                {
                    Result = new { Route = busRoute }
                };
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError($"An error occured : {ex.Message}");

                // Log a custom error 
                result = new OperationResult
                {
                    ErrorMessage = " A server error occured",
                    Status = (int)HttpStatusCode.InternalServerError
                };           
            }
            // Return an the appropriate response
            return result;
        }

        /// <summary>
        /// This function Updates the bus Routes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OperationResult> UpdateRoutes(string id, BusRoutesApiModel model)
        {
            // Initialize operation result
            OperationResult result;
            try
            {
                // Fetch the bus routes from the database by the id
                var busRoutes = await _context.BusRoutes.FirstOrDefaultAsync(x => x.Id == id);

                // Perform a null check 
                if (busRoutes == null)
                {
                    // Return an error if route is not found
                    return new OperationResult
                    {
                        ErrorMessage = "Not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }

                // Set the new information
                busRoutes.RouteInfo = model.RouteInfo;
                busRoutes.RouteTitle = model.RouteTitle;
                busRoutes.Price = model.Price;

                // Update the price in the database
                _context.BusRoutes.Update(busRoutes);

                // Save the changes to the database
                await _context.SaveChangesAsync();

                // Return the result
                return new OperationResult
                {
                    Result = new { BusRoute = model }
                };
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError($"An error occured : ${ex.Message}");

                // Return a Custom error
                result = new OperationResult
                {
                    ErrorMessage = " A server error occured",
                    Status = (int)HttpStatusCode.InternalServerError
                };
            }
            // Return the appropriate result 
            return result;
        }
        /// <summary>
        /// This deletes the routes by the selected id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OperationResult> DeleteRoutes(string id)
        {
            // Initialize the operation result
            OperationResult result;
            try
            {
                // This selects the id from the database
                var busRouteById = await _context.BusRoutes.FindAsync(id);

                // This performs a null check
                if (busRouteById == null)
                {
                    // Return an error
                    return new OperationResult
                    {
                        ErrorMessage = "Id not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }
                // Remove the record from the database 
                _context.BusRoutes.Remove(busRouteById);

                // Return a no content result
                result =  new OperationResult
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
