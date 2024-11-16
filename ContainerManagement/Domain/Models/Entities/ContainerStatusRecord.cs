namespace DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

public class ContainerStatusRecord
{
	public int Id { get; set; }
	public int ContainerId { get; set; }
    public double? Temperature { get; set; }
	public double? Humidity { get; set; }
	public double? GasOxygen { get; set; }
	public double? GasCO2 { get; set; }
	public double? GasEthylene { get; set; }
	public double? GasAmmonia { get; set; }
	public double? GasSO2 { get; set; }
	public DateTime SavedAt { get; set; }

    public ContainerStatusRecord() { }
}
