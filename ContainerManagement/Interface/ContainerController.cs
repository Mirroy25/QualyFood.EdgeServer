using DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DittoBox.EdgeServer.ContainerManagement.Interface
{
    [Route("api/v1/container")]
    [ApiController]
    public class ContainerController(
		IGetContainersQueryHandler getContainersQueryHandler
	) : ControllerBase
    {
        // Cloud Service sends requests to this endpoint to forward them to the container service. The edge server will analyze and decide whether to forward the request to the container service or aggregate it with other requests. Most likely it will just forward the request to the container.

		[HttpGet]
		public async Task<IActionResult> GetRegisteredContainers() {
			var response = await getContainersQueryHandler.Handle();
			return Ok(response);
		}
    }
}
