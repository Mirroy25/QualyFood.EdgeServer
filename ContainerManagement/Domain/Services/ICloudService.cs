using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.EdgeServer.ContainerManagement.Domain.Services
{
    public interface ICloudService
    {
		public Task SendContainerStatusReport(ContainerStatusRecord record);
    }
}
