using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelSafeBookingApi.ApiModels;
using TravelSafeBookingApi.DomainOperations;
using TravelSafeBookingApi.EndpointRoutes;

namespace TravelSafeBookingApi.Controllers
{
    
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly BusOperations _operation;
        public BusController(BusOperations operation)
        {
            _operation = operation;
        }
        [HttpPost(EndpointRoute.CreateBusInfo)]
        public async Task<ActionResult> CreateBuses(BusesApiModel model)
        {
            var operation = await _operation.CreateBuses(model);
            if (!operation.Sucessful)
            {
                return Problem(
                    detail: operation.ErrorMessage,
                    statusCode: operation.Status
                     );
            }
            return Created(string.Empty, model);
        }
        [HttpGet(EndpointRoute.GetBusInfo)]
        public async Task<ActionResult<IEnumerable<BusesApiModel>>> GetBuses()
        {
            var busRoutes = await _operation.FetchBuses();
            return Ok(busRoutes);
        }
        [HttpGet(EndpointRoute.GetBusInfoById)]
        public async Task<ActionResult> GetBusesById(string id)
        {
            var stateById = await _operation.FetchBusesById(id);
            if (!stateById.Sucessful)
            {
                return Problem(
                    detail: stateById.ErrorMessage,
                    statusCode: stateById.Status
                    );
            }
            return Ok(stateById);
        }
        [HttpPut(EndpointRoute.EditBusInfo)]
        public async Task<ActionResult> UpdateBuses(string id, BusesApiModel model)
        {
            var updatedRoute = await _operation.EditBuses(id, model);
            if (updatedRoute.Sucessful)
            {
                return Problem(
                    detail: updatedRoute.ErrorMessage,
                    statusCode: updatedRoute.Status
                    );
            }
            return Ok(updatedRoute);
        }
        [HttpDelete(EndpointRoute.DeleteBusInfo)]
        public async Task<ActionResult> DeleteBuses(string id)
        {
            await _operation.DeleteBus(id);
            return NoContent();
        }
    }
}

