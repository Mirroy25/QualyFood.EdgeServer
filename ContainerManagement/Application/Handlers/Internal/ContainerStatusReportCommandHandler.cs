using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.ValueObjects;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces
{
	public class ContainerStatusReportCommandHandler(
		IContainerService containerService,
		ICloudService cloudService,
        IUnitOfWork unitOfWork,
        IConfiguration configuration
	) : IContainerStatusReportCommandHandler
	{
        private readonly int _maxMillisecondsBetweenReports = Convert.ToInt32(Environment.GetEnvironmentVariable("MAX_MILLISECONDS_BETWEEN_REPORTS") ?? "60000");

        public async Task Handle(ContainerStatusReportCommand command)
        {
            Container? container = await containerService.GetContainerById(command.ContainerId);

            // If not found by Id, try to find by DeviceId
            if (container == null && !string.IsNullOrEmpty(command.DeviceId))
            {
                container = await containerService.GetContainerByUIID(command.DeviceId);
            }


            // If still not found, create a new container
            if (container == null && !string.IsNullOrEmpty(command.DeviceId))
            {
                container = await containerService.CreateContainer(command.DeviceId);
                await unitOfWork.CommitAsync();
            }

            // If still not found, throw an exception
            if (container == null)
            {
                throw new Exception("Container not found. Couldn't create a new container.");
            }

            // Generate the status report
            var statusRecord = new ContainerStatusRecord
            {
                ContainerId = container.Id,
                Temperature = command.Temperature,
                Humidity = command.Humidity,
                GasOxygen = command.GasOxygen,
                GasCO2 = command.GasCO2,
                GasEthylene = command.GasEthylene,
                GasAmmonia = command.GasAmmonia,
                GasSO2 = command.GasSO2,
                SavedAt = DateTime.Now
            };

            // Generate the health reports
            var healthRecords = new List<ContainerHealthRecord>
            {
                new() {
                    ContainerId = container.Id,
                    SensorType = SensorType.GAS_SENSOR,
                    FailuresSinceStartup = command.GasHealthMonitor.FailuresSinceStartup,
                    FailuresSinceLastCheck = command.GasHealthMonitor.FailuresSinceLastCheck,
                    RequestsSinceLastCheck = command.GasHealthMonitor.RequestsSinceLastCheck,
                    RequestsSinceStartup = command.GasHealthMonitor.RequestsSinceStartup,
                    FailingRate = command.GasHealthMonitor.FailingRate,
                    SavedAt = DateTime.Now
                },
                new() {
                    ContainerId = container.Id,
                    SensorType = SensorType.TEMPERATURE_SENSOR,
                    FailuresSinceStartup = command.TemperatureHealthMonitor.FailuresSinceStartup,
                    FailuresSinceLastCheck = command.TemperatureHealthMonitor.FailuresSinceLastCheck,
                    RequestsSinceLastCheck = command.TemperatureHealthMonitor.RequestsSinceLastCheck,
                    RequestsSinceStartup = command.TemperatureHealthMonitor.RequestsSinceStartup,
                    FailingRate = command.TemperatureHealthMonitor.FailingRate,
                    SavedAt = DateTime.Now
                },
                new() {
                    ContainerId = container.Id,
                    SensorType = SensorType.HUMIDITY_SENSOR,
                    FailuresSinceStartup = command.HumidityHealthMonitor.FailuresSinceStartup,
                    FailuresSinceLastCheck = command.HumidityHealthMonitor.FailuresSinceLastCheck,
                    RequestsSinceLastCheck = command.HumidityHealthMonitor.RequestsSinceLastCheck,
                    RequestsSinceStartup = command.HumidityHealthMonitor.RequestsSinceStartup,
                    FailingRate = command.HumidityHealthMonitor.FailingRate,
                    SavedAt = DateTime.Now
                }
            };

            // Save the health reports
            foreach (var healthRecord in healthRecords)
            {
                await containerService.SaveHealthReport(healthRecord);
            }

            // Save the status report
            await containerService.SaveStatusReport(statusRecord);

            // Commit the changes
            await unitOfWork.CommitAsync();

            // ----

            // Send the report to the cloud if necessary
            if (container.LastSentStatusReport == null || container.LastSentStatusReport < DateTime.Now.AddMinutes(-1))
            {
                await containerService.SendReportToCloud(container.Id, _maxMillisecondsBetweenReports);
                
            }

            await unitOfWork.CommitAsync();
        }
    }
}