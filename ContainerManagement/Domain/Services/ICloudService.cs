using DittoBox.EdgeServer.ContainerManagement.Application.Resources;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.EdgeServer.ContainerManagement.Domain.Services
{
	public interface ICloudService
	{
		public Task SendContainerStatusReport(ContainerStatusRecord record);
		public Task<ContainerRegistrationResource> RegisterContainer(string uiid);

	}
}
