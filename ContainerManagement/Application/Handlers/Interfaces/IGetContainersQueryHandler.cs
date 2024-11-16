using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces
{
	public interface IGetContainersQueryHandler
	{
		Task<IEnumerable<Container>> Handle();
	}
}