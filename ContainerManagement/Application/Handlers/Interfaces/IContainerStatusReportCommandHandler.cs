namespace DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces
{
	public interface IContainerStatusReportCommandHandler
	{
		Task Handle(ContainerStatusReportCommand command);
	}
}