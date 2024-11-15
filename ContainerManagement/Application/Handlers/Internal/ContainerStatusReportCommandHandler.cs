using DittoBox.EdgeServer.ContainerManagement.Application.Services;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces
{
	public class ContainerStatusReportCommandHandler(
		IContainerService containerService
	) : IContainerStatusReportCommandHandler
	{
		public Task Handle(ContainerStatusReportCommand command)
		{
			throw new NotImplementedException();
		}
	}
}