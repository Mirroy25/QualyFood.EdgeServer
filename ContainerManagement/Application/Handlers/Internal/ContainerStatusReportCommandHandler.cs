using DittoBox.EdgeServer.ContainerManagement.Application.Services;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces
{
	public class ContainerStatusReportCommandHandler(
		IContainerService containerService,
		ICloudService cloudService
	) : IContainerStatusReportCommandHandler
	{
		public async Task Handle(ContainerStatusReportCommand command)
		{
			var container = await containerService.GetContainerById(command.ContainerId);
			if (container == null)
			{
				throw new Exception("Container not found");
			}

			var record = new ContainerStatusRecord
			{
				Temperature = command.Temperature,
				Humidity = command.Humidity,
				GasOxygen = command.GasOxygen,
				GasCO2 = command.GasCO2,
				GasEthylene = command.GasEthylene,
				GasAmmonia = command.GasAmmonia,
				GasSO2 = command.GasSO2,
			};

			await cloudService.SendContainerStatusReport(record);
		}
	}
}