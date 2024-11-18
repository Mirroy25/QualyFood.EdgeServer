using DittoBox.EdgeServer.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

public class ContainerHealthRecord
{
	public int Id { get; set; }
	public int ContainerId { get; set; }
	public SensorType SensorType { get; set; }
	public int FailuresSinceStartup { get; set; }
	public int FailuresSinceLastCheck { get; set; }
	public int RequestsSinceLastCheck { get; set; }
	public int RequestsSinceStartup { get; set; }
	public double FailingRate { get; set; }
	public DateTime SavedAt { get; set; }

	public ContainerHealthRecord() { }
}