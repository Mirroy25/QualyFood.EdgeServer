using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DittoBox.EdgeServer.ContainerManagement.Interface
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudServiceController : ControllerBase
    {
        // Containers send requests to this endpoint to forward them to the cloud service. The edge server will analyze and decide whether to forward the request to the cloud service or aggregate it with other requests.
    }
}
