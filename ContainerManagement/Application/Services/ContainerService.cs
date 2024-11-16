using DittoBox.EdgeServer.ContainerManagement.Application.Resources.Outbound;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Services
{
	public class ContainerService(
        IContainerRepository containerRepository,
        IContainerHealthRecordRepository containerHealthRecordRepository,
		IContainerStatusRecordRepository containerStatusRecordRepository,
        ILogger<ContainerService> logger
    ) : BaseService, IContainerService
	{
        public async Task<Container> CreateContainer(string uiid, string? macAddress = null)
        {
			var container = new Container() { UIID = uiid, MACAddress = macAddress };
            await containerRepository.Add(container);
            return container;

        }

        public Task ForwardNewTemplateSettings()
		{
			throw new NotImplementedException();
		}

        public async Task<Container?> GetContainerById(int containerId)
        {
			return await containerRepository.GetById(containerId);
        }

        public Task<Container?> GetContainerByUIID(string uiid)
        {
            return containerRepository.GetContainerByUIID(uiid);
        }

        public Task<bool> IsReportToCloudRequired(int containerId)
		{
			throw new NotImplementedException();
		}

		public async Task SaveHealthReport(ContainerHealthRecord healthReport)
		{
			await containerHealthRecordRepository.Add(healthReport);
        }

		public async Task SaveStatusReport(ContainerStatusRecord statusReport)
		{
			await containerStatusRecordRepository.Add(statusReport);
        }

        public async Task SendReportToCloud(int containerId, int timeframe)
        {
            // Send a report with a POST request to the cloud
            var container = await containerRepository.GetById(containerId);
            // Get the health report from the last 1 minute
            var from = DateTime.Now.AddMinutes(-timeframe);
            var statusReports = await containerStatusRecordRepository.GetLatestReportsByTime(containerId, from);

            // Send the report to the cloud
            var client = new HttpClient();
            // Make a ContainerMetricsResource by the average of all the health reports
            var statusResource = new ContainerMetricsResource()
            {
                Temperature = statusReports.Average(r => r.Temperature),
                Humidity = statusReports.Average(r => r.Humidity),
                Oxygen = statusReports.Average(r => r.GasOxygen),
                Dioxide = statusReports.Average(r => r.GasCO2),
                Ethylene = statusReports.Average(r => r.GasEthylene),
                Ammonia = statusReports.Average(r => r.GasAmmonia),
                SulfurDioxide = statusReports.Average(r => r.GasSO2)
            };

            var response = await client.PutAsJsonAsync(Path.Combine(BaseUrl, $"container/{container!.Id}/metrics"),statusResource);
            if (response.IsSuccessStatusCode)
            {

                container.LastSentStatusReport = DateTime.Now;
                await containerRepository.Update(container);
                logger.LogInformation($"Status report sent to cloud for container {container.Id} at {container.LastSentStatusReport}");
                return;
            }
            else
            {
                logger.LogError($"Failed to send report to cloud. Status code: {response.StatusCode}.\n{response.Content}");
                throw new Exception($"Failed to send report to cloud.");
            }
        }
    }
}
