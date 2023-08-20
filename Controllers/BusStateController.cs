using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelSafeBookingApi.ApiModels;
using TravelSafeBookingApi.DomainOperations;
using TravelSafeBookingApi.EndpointRoutes;

namespace TravelSafeBookingApi.Controllers
{
    [ApiController]
    public class BusStateController : ControllerBase
    {
        private readonly BusStateOperations _operation;
        public BusStateController(BusStateOperations operation)
        {
            _operation = operation;
        }
        [HttpPost(EndpointRoute.CreateStateInfo)]
        public async Task<ActionResult> CreateStateInfo(StatesApiModel model)
        {
            var operation = await _operation.CreateStateInfo(model);
            if (!operation.Sucessful)
            {
                return Problem(
                    detail: operation.ErrorMessage,
                    statusCode: operation.Status
                     );
            }
            return Created(string.Empty, model);
        }
        [HttpGet(EndpointRoute.GetStateInfo)]
        public async Task<ActionResult<IEnumerable<StatesApiModel>>> GetStatesInfo()
        {
            var busRoutes = await _operation.FetchStateInfo();
            return Ok(busRoutes);
        }
        [HttpGet(EndpointRoute.GetStateInfoById)]
        public async Task<ActionResult> GetStateById (string id)
        {
            var stateById = await _operation.FetchStateInfoById(id);
            if (!stateById.Sucessful)
            {
                return Problem(
                    detail: stateById.ErrorMessage,
                    statusCode: stateById.Status
                    );
            }
            return Ok(stateById);
        }
        [HttpPut(EndpointRoute.UpdateStateInfo)]
        public async Task<ActionResult> UpdateStateInfo(string id, StatesApiModel model)
        {
            var updatedRoute = await _operation.EditStateInfo(id, model);
            if (updatedRoute.Sucessful)
            {
                return Problem(
                    detail: updatedRoute.ErrorMessage,
                    statusCode: updatedRoute.Status
                    );
            }
            return Ok(updatedRoute);
        }
        [HttpDelete(EndpointRoute.DeleteStateInfo)]
        public async Task<ActionResult> DeleteStateInfo(string id)
        {
            await _operation.DeleteStateInfo(id);
            return NoContent();
        }
    }
}

