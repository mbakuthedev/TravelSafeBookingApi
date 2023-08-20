using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TravelSafeBookingApi.ApiModels;
using TravelSafeBookingApi.DataModels;
using TravelSafeBookingApi.DomainOperations;
using TravelSafeBookingApi.EndpointRoutes;

namespace TravelSafeBookingApi.Controllers
{

    [ApiController]
    public class BusRouteController : ControllerBase
    {
        private readonly RouteOperation _operation;
        public BusRouteController(RouteOperation operation)
        {
            _operation = operation;
        }
        [HttpPost(EndpointRoute.CreateRoute)]
        public async Task<ActionResult> CreateBusRoute(BusRoutesApiModel model)
        {
            var operation =await _operation.CreateRoutes(model);
            if (!operation.Sucessful)
            {
                return Problem(
                    detail: operation.ErrorMessage,
                    statusCode: operation.Status
                     );
            }
            return Created(string.Empty, model);
        }
        [HttpGet(EndpointRoute.GetRoutes)]
        public async Task<ActionResult<IEnumerable<BusRoutesApiModel>>> GetBusRoutes()
        {
            var busRoutes = await _operation.GetAllRoutes();
            return Ok(busRoutes);
        }
        [HttpGet(EndpointRoute.GetRoutesById)]
        public async Task<ActionResult> GetBusRoutesById(string id)
        {
            var busRoute = await _operation.GetRoutesById(id);
            if (!busRoute.Sucessful)
            {
                return Problem(
                    detail: busRoute.ErrorMessage,
                    statusCode: busRoute.Status
                    );
            }
            return Ok(busRoute);
        }
        [HttpPut(EndpointRoute.UpdateRoute)]
        public async Task<ActionResult> UpdateBusRoutes(string id, BusRoutesApiModel model)
        {
            var updatedRoute =await _operation.UpdateRoutes(id, model);
            if (updatedRoute.Sucessful)
            {
                return Problem(
                    detail: updatedRoute.ErrorMessage,
                    statusCode: updatedRoute.Status
                    );
            }
            return Ok(updatedRoute);
        }
        [HttpDelete(EndpointRoute.DeleteRoute)]
        public async Task<ActionResult> DeleteRoute(string id)
        {
            await _operation.DeleteRoutes(id);
            return NoContent();
        }
    }
}
