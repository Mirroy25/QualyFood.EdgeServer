using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Resources.Outbound
{
    public record ContainerMetricsResource
    {
        public double? Temperature { get; init; }
        public double? Humidity { get; init; }
        public double? Oxygen { get; init; }
        public double? Dioxide { get; init; }
        public double? Ethylene { get; init; }
        public double? Ammonia { get; init; }
        public double? SulfurDioxide { get; init; }

        public static ContainerMetricsResource FromContainerStatusRecord(ContainerStatusRecord containerStatusReport)
        {
            return new ContainerMetricsResource()
            {
                Temperature = containerStatusReport.Temperature,
                Humidity = containerStatusReport.Humidity,
                Oxygen = containerStatusReport.GasOxygen,
                Dioxide = containerStatusReport.GasCO2,
                Ethylene = containerStatusReport.GasEthylene,
                Ammonia = containerStatusReport.GasAmmonia,
                SulfurDioxide = containerStatusReport.GasSO2
            };
        }
    }
}
