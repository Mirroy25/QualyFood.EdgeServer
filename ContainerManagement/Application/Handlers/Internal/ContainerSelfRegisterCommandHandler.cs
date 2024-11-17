using DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.EdgeServer.ContainerManagement.Application.Resources;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Internal
{
	public class ContainerSelfRegisterCommandHandler(
		ICloudService cloudService,
		IUnitOfWork unitOfWork
	) : IContainerSelfRegisterCommandHandler
	{
		public async Task<ContainerRegistrationResource> Handle(ContainerSelfRegisterCommand command)
		{
			var result = await cloudService.RegisterContainer(command.Uiid);
			await unitOfWork.CommitAsync();
			return result;
		}
	}
}