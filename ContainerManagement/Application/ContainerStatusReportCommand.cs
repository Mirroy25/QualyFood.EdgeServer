using System.ComponentModel.DataAnnotations;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.EdgeServer.ContainerManagement.Application
{
    public record ContainerStatusReportCommand
    {
		[Required]
		public int ContainerId { get; set; }
        [Required]
        public string? DeviceId { get; set; }
        [Required]
        public double? Temperature { get; set; }
        [Required]
        public double? Humidity { get; set; }
        [Required]
        public double? GasOxygen { get; set; }
        [Required]
        public double? GasCO2 { get; set; }
        [Required]
        public double? GasEthylene { get; set; }
        [Required]
        public double? GasAmmonia { get; set; }
        [Required]
        public double? GasSO2 { get; set; }
        [Required]
        public HealthMonitor GasHealthMonitor { get; set; } = new HealthMonitor();
        [Required]
        public HealthMonitor TemperatureHealthMonitor { get; set; } = new HealthMonitor();
        [Required]
        public HealthMonitor HumidityHealthMonitor { get; set; } = new HealthMonitor();
    }
}
