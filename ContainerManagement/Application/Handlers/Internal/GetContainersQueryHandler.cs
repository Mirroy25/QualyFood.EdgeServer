using DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Internal
{
	public class GetContainersQueryHandler(
		IContainerService containerService
	) : IGetContainersQueryHandler
	{
		public async Task<IEnumerable<Container>> Handle()
		{
			return await containerService.GetContainers();
		}
	}
}