using DittoBox.EdgeServer.ContainerManagement.Application.Services;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.EdgeServer.ContainerManagement.Domain.Services
{
    public interface IContainerService
    {
		public Task SaveHealthReport(ContainerHealthRecord healthReport);
		public Task SaveStatusReport(ContainerStatusRecord statusReport);
		public Task<bool> IsReportToCloudRequired();
		public Task ForwardNewTemplateSettings();
		public Task<Container> GetContainerById(int containerId);
	}
}
