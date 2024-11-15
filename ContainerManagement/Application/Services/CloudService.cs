using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Services
{
	public class CloudService : BaseService, ICloudService
	{
		public Task SendContainerStatusReport(ContainerStatusRecord record)
		{
			throw new NotImplementedException();
		}
	}
}
