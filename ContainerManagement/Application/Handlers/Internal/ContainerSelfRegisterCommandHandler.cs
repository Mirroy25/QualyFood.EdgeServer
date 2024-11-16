using DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Internal
{
	public class ContainerSelfRegisterCommandHandler(
		ICloudService cloudService,
		IUnitOfWork unitOfWork
	) : IContainerSelfRegisterCommandHandler
	{
		public async Task Handle(ContainerSelfRegisterCommand command)
		{
			await cloudService.RegisterContainer(command.Uiid);
			await unitOfWork.CommitAsync();
		}
	}
}