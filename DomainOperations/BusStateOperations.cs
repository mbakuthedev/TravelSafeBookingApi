using System.Net;
using TravelSafeBookingApi.ApiModels.OperationResults;
using TravelSafeBookingApi.ApiModels;
using TravelSafeBookingApi.Data;
using TravelSafeBookingApi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace TravelSafeBookingApi.DomainOperations
{
    public class BusStateOperations
    {
        /// <summary>
        /// Scoped instance of the db context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Scoped instance of the logger
        /// </summary>
        private readonly ILogger<BusStateOperations> _logger;

        /// <summary>
        /// Constructor for DI
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public BusStateOperations(ApplicationDbContext context, ILogger<BusStateOperations> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OperationResult> CreateStateInfo(StatesApiModel model)
        {
            // Initialize operation result
            OperationResult result;
            try
            {
                // Create StateInfo details 
                var stateInfo = new StatesDataModel
                {
                   StateName = model.StateName,
                   StateDescription = model.StateDescription,
                   TouristCenters = model.TouristCenters
                };
                await _context.StatesInfo.AddAsync(stateInfo);
                _context.SaveChanges();

                result = new OperationResult
                {
                    Result = new { stateInfo }
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
        public async Task<OperationResult> EditStateInfo(string id, StatesApiModel model)
        {
            OperationResult result;

            try
            {
                var stateInfo = await _context.StatesInfo.FirstOrDefaultAsync(x => x.Id == id);
                if (stateInfo == null)
                {
                    result = new OperationResult
                    {
                        ErrorMessage = "Not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }

                stateInfo.StateName = model.StateName;
                stateInfo.StateDescription = model.StateDescription;
                stateInfo.TouristCenters = model.TouristCenters;
                _context.StatesInfo.Update(stateInfo);
                await _context.SaveChangesAsync();

                result = new OperationResult
                {
                    Result = new { stateInfo }
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
        public async Task<IEnumerable<StatesDataModel>> FetchStateInfo()
        {
            return await _context.StatesInfo.ToListAsync();
        }
        public async Task<OperationResult> FetchStateInfoById(string id)
        {
            OperationResult result;
            try
            {
                var stateInfo = await _context.StatesInfo.FirstOrDefaultAsync(x => x.Id == id);
                if (stateInfo == null)
                {
                    result = new OperationResult
                    {
                        ErrorMessage = "Not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }
                result = new OperationResult
                {
                    Result = new { stateInfo }
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

        public async Task<OperationResult> FetchStateInfoByStateName(StatesApiModel model)
        {
            OperationResult result;
            try
            {
                var stateInfo = await _context.StatesInfo.FirstOrDefaultAsync(x => x.Id == model.StateName);
                if (stateInfo == null)
                {
                    result = new OperationResult
                    {
                        ErrorMessage = "Not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }
                return result = new OperationResult
                {
                    Result = new { stateInfo }
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
        public async Task<OperationResult> DeleteStateInfo(string id)
        {
            // Initialize the operation result
            OperationResult result;
            try
            {
                // This selects the id from the database
                var stateInfoById = await _context.StatesInfo.FindAsync(id);

                // This performs a null check
                if (stateInfoById == null)
                {
                    // Return an error
                    return new OperationResult
                    {
                        ErrorMessage = "Id not found",
                        Status = (int)HttpStatusCode.NotFound
                    };
                }
                // Remove the record from the database 
                _context.StatesInfo.Remove(stateInfoById);

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
