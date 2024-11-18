using DittoBox.EdgeServer.ContainerManagement.Application.Services;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.EdgeServer.ContainerManagement.Domain.Services
{
    public interface IContainerService
    {
		public Task SaveHealthReport(ContainerHealthRecord healthReport);
		public Task SaveStatusReport(ContainerStatusRecord statusReport);
		public Task<bool> IsReportToCloudRequired(int containerId);
		public Task ForwardNewTemplateSettings();
		public Task<Container?> GetContainerById(int containerId);
		public Task<IEnumerable<Container>> GetContainers();
		public Task<Container?> GetContainerByUIID(string uiid);
        public Task<Container> CreateContainer(string uiid, int idInCloud);
		public Task SendReportToCloud(int containerId, int timeframe);
    }
}
