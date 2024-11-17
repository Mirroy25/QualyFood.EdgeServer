using DittoBox.EdgeServer.ContainerManagement.Application.Resources;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces
{
	public interface IContainerSelfRegisterCommandHandler
	{
		Task<ContainerRegistrationResource> Handle(ContainerSelfRegisterCommand command);
	}
}