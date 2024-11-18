namespace DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

public class Container
{
    public int Id { get; set; }
	public int IdInCloudService { get; set; } // Id of the container in the cloud service. 
    public string UIID { get; set; } // Unique internal identifier. Hardcoded value on each container microcontroller.
    public string? MACAddress { get; set; } // MAC address of the container microcontroller.
    public DateTime? LastSentStatusReport { get; set; } // Last time a the container's status report was sent to the cloud.
    public DateTime? LastSentHealthReport { get; set; } // Last time the container's health report was sent to the cloud.
}