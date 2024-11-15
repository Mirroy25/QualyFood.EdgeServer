
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.EdgeServer.ContainerManagement.Application
{
    public class HealthMonitor
    {
		public SensorType? SensorType { get; set; }
        public int FailingRatePeriodCycles { get; set; }
        public int FailuresSinceStartup { get; set; }
        public int RemainingCycles { get; set; }
        public int FailuresSinceLastCheck { get; set; }
        public int RequestsSinceLastCheck { get; set; }
        public int RequestsSinceStartup { get; set; }
        public double FailingRate { get; set; }
		public DateTime SavedAt { get; set; }
    }
}