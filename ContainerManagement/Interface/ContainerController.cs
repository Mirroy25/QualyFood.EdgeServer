using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DittoBox.EdgeServer.ContainerManagement.Interface
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        // Cloud Service sends requests to this endpoint to forward them to the container service. The edge server will analyze and decide whether to forward the request to the container service or aggregate it with other requests. Most likely it will just forward the request to the container.
    }
}
