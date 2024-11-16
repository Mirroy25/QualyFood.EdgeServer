namespace DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces
{
	public interface IContainerSelfRegisterCommandHandler
	{
		Task Handle(ContainerSelfRegisterCommand command);
	}
}